using WPF.Models.Dtos.Category;

namespace WPF.Services.Contracts
{
    public interface ICategoryService
    {
        Task<GetCategoryDto> CreateCategoryAsync(CreateCategoryDto dto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<IEnumerable<GetCategoryDto>> GetCategoryAsync();
        Task<GetCategoryDto> GetCategoryByIdAsync(int id);
        Task<IEnumerable<GetCategoryDto>> GetCategoryBySearchAsync(string categoryName);
        Task<GetCategoryDto> UpdateCategoryAsync(UpdateCategoryDto dto);
    }
}