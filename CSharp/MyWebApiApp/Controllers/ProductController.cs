using MyWebApiApp.Models;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Services;
using MyWebApiApp.DTO;

namespace MyWebApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsResponseDto>>> GetAll()
        {
            var all_Products = await productService.GetAllProducts();
            var response =all_Products.Select(pro => new ProductsResponseDto
            {
                Fruit_name = pro.Name,
                Fruit_price = pro.Price,
                Fruit_img = pro.Img_url
                
            }) ;
            
            return Ok(all_Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsResponseDto>> GetById(int id)
        {
            var this_product = await productService.GetProductById(id);
            var response = new ProductsResponseDto
            {
                Fruit_name = this_product.Name,
                Fruit_price = this_product.Price,
                Fruit_img = this_product.Img_url
                
            };
            
            if (this_product == null)
            {
                return NotFound("Subject not found");
            }
            return Ok(response);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Products subProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdProduct = await productService.AddProductAsync(subProduct);
            return Ok(createdProduct);
        }


    }
}   