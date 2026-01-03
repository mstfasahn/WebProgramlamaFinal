using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Product
{
    public class UpdateProductDto:CreateProductDto
    {
        public int Id { get; set; }
        public List<string>? ExistingImageUrls { get; set; }
    }
}
