using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;  
        }

        [HttpGet]
        public ActionResult<List<Product>> FindAll()
        {
            return Ok(_productService.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductVO> FindById(long id)
        {
            return Ok(_productService.FindById(id));
        }
    }
}
