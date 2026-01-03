using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Product
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Baþlýk zorunludur.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açýklama zorunludur.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ISBN zorunludur.")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Yazar zorunludur.")]
        public string Author { get; set; }
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }
        public int CategoryId { get; set; }

        public List<IFormFile>? ImageFiles { get; set; }
    }
}
