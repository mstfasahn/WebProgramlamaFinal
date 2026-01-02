using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.Category
{
    // CategoryDto.cs
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
