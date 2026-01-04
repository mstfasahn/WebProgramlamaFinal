using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Constants;
using WPF.Models.Dtos.Product;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class ProductService(ApplicationDbContext dbContext,
        IMapper mapper,
        IWebHostEnvironment _webHostEnvironment) : IProductService
    {

        public async Task<GetProductDto> GetProductByIdAsync(int productId)
        {
            var product = await dbContext.Products.FindAsync(productId);
            if (product == null) { return new GetProductDto(); }
            var getProductDto =mapper.Map<GetProductDto>(product);
            return getProductDto;
        }
        public async Task CreateProductAsync(CreateProductDto dto, int currentUserId)
        {
            var product = mapper.Map<Product>(dto);
            product.UserId = currentUserId;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            // 2. Resimler varsa klasöre kaydet ve DB iliþkisini kur
            if (dto.ImageFiles != null && dto.ImageFiles.Any())
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath; // IWebHostEnvironment enjekte edilmeli

                foreach (var file in dto.ImageFiles)
                {
                    // Benzersiz isim oluþtur (Guid)
                    string productFolderName = "product-" + product.Id;
                    string productPath = Path.Combine(wwwRootPath, "images", "products", productFolderName);

                    // Klasör yoksa oluþtur
                    if (!Directory.Exists(productPath))
                        Directory.CreateDirectory(productPath);

                    using (var fileStream = new FileStream(Path.Combine(productPath, productFolderName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    // ProductImage tablosuna kaydet
                    var productImage = new ProductImage
                    {
                        ImageUrl = @"\images\products\product-" + product.Id + @"\" + productFolderName,
                        ProductId = product.Id
                    };
                    await dbContext.ProductImages.AddAsync(productImage);
                }
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GetProductDto>> GetManagementProductsAsync(int currentUserId, int roleId)
        {
            if (roleId != (int)UserRole.Admin && roleId != (int)UserRole.BusinessAccount)
            {
                return Enumerable.Empty<GetProductDto>();
            }

            var query = dbContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.ProductImages)
                    .AsNoTracking();

            if (roleId != (int)UserRole.Admin)
            {
                query = query.Where(p => p.UserId == currentUserId);
            }
            var products = await query.ToListAsync();
            var getProductDtos = mapper.Map<IEnumerable<GetProductDto>>(products);
            return getProductDtos;
        }

        public async Task<IEnumerable<GetProductDto>> GetAllPublicProductsAsync()
        {
            var products = await dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<IEnumerable<GetProductDto>>(products);
        }

        public async Task<UpdateProductDto> GetProductForUpdateAsync(int id, int userId, int roleId)
        {
            var product = await dbContext.Products
                .FirstOrDefaultAsync(
                p => p.Id == id && p.UserId == userId);
            if (product == null) { return null; }
            return mapper.Map<UpdateProductDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            var productInDb = await dbContext.Products
            .Include(p => p.ProductImages)
            .FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (productInDb == null) return;

            mapper.Map(dto,productInDb);
            if (dto.ImageFiles != null && dto.ImageFiles.Count > 0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string productFolderName = "product-" + productInDb.Id;
                string finalPath = Path.Combine(wwwRootPath, "images", "products", productFolderName);

                if (!Directory.Exists(finalPath)) Directory.CreateDirectory(finalPath);

                foreach (var file in dto.ImageFiles)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(finalPath, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    productInDb.ProductImages.Add(new ProductImage
                    {
                        ImageUrl = $"/images/products/{productFolderName}/{fileName}",
                        ProductId = productInDb.Id
                    });
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id,int userId,int RoleId)
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product == null) { return false; }

            if (RoleId == (int)UserRole.Admin)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
                return true;
            }
            if(RoleId == (int)UserRole.BusinessAccount && product.UserId==userId)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
    }


