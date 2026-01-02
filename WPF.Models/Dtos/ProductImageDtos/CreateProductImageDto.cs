using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.ProductImage
{
    public class CreateProductImageDto
    {
        [Required]
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
