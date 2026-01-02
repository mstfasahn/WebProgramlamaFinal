using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.ShoppingCart
{
    public class UpdateShoppingCartDto:CreateShoppingCartDto
    {
        public int Id { get; set; }
    }
}
