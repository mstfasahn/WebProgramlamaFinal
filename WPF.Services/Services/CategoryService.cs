using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.Category;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class CategoryService(ApplicationDbContext dbContext, IMapper mapper) : ICategoryService
    {
        public async Task<IEnumerable<GetCategoryDto>> GetCategoryAsync()
        {
            var Categories = await dbContext.Categories.AsNoTracking().OrderBy(c => c.DisplayOrder).ToListAsync();
            var CategoriesDto = mapper.Map<IEnumerable<GetCategoryDto>>(Categories);
            return CategoriesDto;
        }

        public async Task<IEnumerable<GetCategoryDto>> GetCategoryBySearchAsync(string categoryName)
        {
            if (String.IsNullOrEmpty(categoryName))
            {
                var all = await dbContext.Categories.ToListAsync();
                return mapper.Map<IEnumerable<GetCategoryDto>>(all);
            }
            var cleanedCategoryName = categoryName.Replace(" ", "").ToUpper();
            var Categories = await dbContext.Categories
                            .AsNoTracking()
                            .Where(c => c.Name.Replace(" ", "").ToUpper().Contains(cleanedCategoryName))
                            .ToListAsync();
            return mapper.Map<IEnumerable<GetCategoryDto>>(Categories);
        }

        public async Task<GetCategoryDto> GetCategoryByIdAsync(int id)
        {
            var Category = await dbContext.Categories.FindAsync(id);
            return mapper.Map<GetCategoryDto>(Category);
        }
        public async Task<GetCategoryDto> CreateCategoryAsync(CreateCategoryDto dto)
        {
            if (dto == null) { throw new ArgumentNullException(nameof(dto)); }
            var Category = mapper.Map<Category>(dto);
            await dbContext.Categories.AddAsync(Category);
            await dbContext.SaveChangesAsync();
            var getCategoryDto = mapper.Map<GetCategoryDto>(Category);
            return getCategoryDto;
        }

        public async Task<GetCategoryDto> UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            if (dto == null) { throw new ArgumentNullException(nameof(dto)); }

            var CategoryInDb = await dbContext.Categories.FindAsync(dto.Id);

            if (CategoryInDb == null)
            {

                throw new KeyNotFoundException("Güncellenecek kategori bulunamadý.");
            }
            mapper.Map(dto, CategoryInDb);
            await dbContext.SaveChangesAsync();
            return mapper.Map<GetCategoryDto>(CategoryInDb);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var item = await dbContext.Categories.FindAsync(id);
            if (item == null) { throw new KeyNotFoundException("Silinecek kategori bulunamadý."); }
            dbContext.Categories.Remove(item);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}

