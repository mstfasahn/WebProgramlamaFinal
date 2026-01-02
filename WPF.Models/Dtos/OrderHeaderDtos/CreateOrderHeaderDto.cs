using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.OrderHeader
{
    public class CreateOrderHeaderDto
    {

        [Required(ErrorMessage = "Telefon zorunludur.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Adres zorunludur.")]
        public string StreetAddress { get; set; }
        [Required(ErrorMessage = "Þehir seçilmelidir.")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Eyalet/Ýl seçilmelidir.")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Alýcý adý zorunludur.")]
        public string Name { get; set; }
    }
}
