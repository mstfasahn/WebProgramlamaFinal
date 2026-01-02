using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Kategori adý zorunludur.")]
        [StringLength(50)]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Sýralama 1-100 arasý olmalýdýr.")]
        public int DisplayOrder { get; set; }
    }
}
