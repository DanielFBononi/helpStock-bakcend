using HelpStockApp.Application.DTOs;
using HelpStockApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpStockApp.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();
            if (products == null)
            {
                return NotFound("Product not found");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Category Not Found");
            }
            return Ok(product);
        }
    }
}

