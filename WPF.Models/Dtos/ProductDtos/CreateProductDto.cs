using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Product
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductDto
    {
        [Required(ErrorMessage = "Ürün baþlýðý zorunludur.")]
        [Display(Name = "Ürün Adý")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açýklama alaný boþ býrakýlamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ISBN alaný zorunludur.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Yazar bilgisi zorunludur.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Liste fiyatý zorunludur.")]
        [Range(1, 50000, ErrorMessage = "Fiyat 1 ile 50.000 arasýnda olmalýdýr.")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "Satýþ fiyatý zorunludur.")]
        [Range(1, 50000, ErrorMessage = "Fiyat 1 ile 50.000 arasýnda olmalýdýr.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kategori seçiniz.")]
        public int CategoryId { get; set; }

        
        public List<IFormFile>? ImageFiles { get; set; }
    }
}
