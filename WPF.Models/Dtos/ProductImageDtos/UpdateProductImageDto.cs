using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.ProductImage
{
    public class UpdateProductImageDto:CreateProductImageDto
    {
        public int Id { get; set; }
    }
}
