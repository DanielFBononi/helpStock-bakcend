using HelpStockApp.Application.DTOs;

namespace HelpStockApp.Application.Interfaces
{
        public interface IProductService
        {
            Task<IEnumerable<ProductDTO>> GetProducts();
            Task<ProductDTO> GetProductById(int? id);
            Task Add(ProductDTO productDTO);
            Task Update(ProductDTO productDTO);
            Task Remove(int? id);
        }
    
}