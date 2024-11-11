using HelpStockApp.Application.DTOs;

namespace HelpStockApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int? id);
        Task Add(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);
        Task Remove(int? id);
    }
}
