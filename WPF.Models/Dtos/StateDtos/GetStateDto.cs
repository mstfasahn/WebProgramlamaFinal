using System.ComponentModel.DataAnnotations;

namespace WPF.Models.Dtos.State
{
    // StateDto.cs
    public class GetStateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
