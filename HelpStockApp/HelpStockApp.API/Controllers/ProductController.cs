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

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }
                await _productService.Add(productDTO);  
                return CreatedAtAction(nameof(Get), new {id = productDTO.Id}, productDTO);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest("id not fund");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productService.Update(productDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product ==null)
            {
                return NotFound();
            }

            await _productService.Remove(id);
            return Ok();
        }
    }
}

