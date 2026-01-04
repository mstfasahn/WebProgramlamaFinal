using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.ShoppingCart;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class ShoppingCartServices
        (ApplicationDbContext dbContext,
        IUserService userService,
        IProductService productService,
        IMapper mapper
        ) : IShoppingCartServices
    {
        public async Task<bool> AddProductInCart(CreateShoppingCartDto dto, int userId)
        {
            var cartFromDb = await dbContext.ShoppingCarts
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == dto.ProductId);

            //Sepette yoksa ekledik.
            if (cartFromDb == null)
            {
                if (dto.Count > 0)
                {
                    var shoppingCart = mapper.Map<ShoppingCart>(dto);
                    shoppingCart.UserId = userId;
                    await dbContext.ShoppingCarts.AddAsync(shoppingCart);
                }
            }

            else
            {
                //Ürün adedini güncelledik
                cartFromDb.Count += dto.Count;

                // Sayý 0 veya altýna düþtüyse SÝL
                if (cartFromDb.Count <= 0)
                {
                    dbContext.ShoppingCarts.Remove(cartFromDb);
                }
                else
                {
                    dbContext.ShoppingCarts.Update(cartFromDb);
                }
            }

            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<GetShoppingCartDto>> GetShoppingCartsForUser(int userId)
        {

            var carts = await dbContext.ShoppingCarts
                .Where(s => s.UserId == userId)
                .Include(s => s.Product)
                .ThenInclude(p => p.ProductImages)
                .ToListAsync();
            var getCartsDto = mapper.Map<IEnumerable<GetShoppingCartDto>>(carts);
            return getCartsDto;
        }

    }
}
