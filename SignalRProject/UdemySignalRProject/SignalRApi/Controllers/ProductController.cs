using AutoMapper;
using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.FeatureDTOs;
using DTOLayer.ProductDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetListProduct()
        {
            var values = _mapper.Map<List<ResultProductDTO>>(_productService.TGetListAll());
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpGet("GetListLast6Product")]
        public IActionResult GetListLast6Product()
        {
            var values = _mapper.Map<List<ResultProductDTO>>(_productService.TGetLast6Product());
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {   //solide aykırı ama bakacağım
            using (var ent = new SignalRContext())
            {
                var values= ent.Products.Include(x => x.Category).Select(x => new ResultProductsWithCategoryDTO
                {
                    CategoryName = x.Category.CategoryName,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName
                }).ToList();
               return Ok(values);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var findProduct = _mapper.Map<GetProductDTO>(_productService.TGetById(id));
            if (findProduct == null)
            {
                return NotFound();
            }
            {
                return Ok(findProduct);
            }
        }
		[HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var productCount = _mapper.Map<int>(_productService.TGetProductCount());
            return Ok(productCount);
        }
		[HttpGet("GetProductCountByDrinks")]
		public IActionResult GetProductCountByDrinks()
		{
			var productCount = _mapper.Map<int>(_productService.TGetProductCountByDrink());
			return Ok(productCount);
		}
		[HttpGet("GetProductCountByHamburger")]
		public IActionResult GetProductCountByHamburger()
		{
			var productCount = _mapper.Map<int>(_productService.TGetProductCountByHamburger());
			return Ok(productCount);
		}
		[HttpGet("GetProductByMaxPrice")]
		public IActionResult GetProductByMaxPrice()
		{
			var productCount = _mapper.Map<int>(_productService.TGetProductByMaxPrice());
			return Ok(productCount);
		}
		[HttpGet("GetProductByMinPrice")]
		public IActionResult GetProductByMinPrice()
		{
			var productCount = _productService.TGetProductByMinPrice();
			return Ok(productCount);
		}
		[HttpGet("GetProductPriceAvg")]
		public IActionResult GetProductPriceAvg()
		{
			var productCount = _mapper.Map<int>(_productService.TGetProductPriceAvg());
			return Ok(productCount);
		}
		[HttpGet("GetProductAvgPriceByHamburger")]
		public IActionResult GetProductAvgPriceByHamburger()
		{
			var productCount = _mapper.Map<int>(_productService.TGetProductAvgPriceByHamburger());
			return Ok(productCount);
		}
		[HttpPost]
        public IActionResult CreateProduct(CreateProductDTO p)
        {
            _productService.TInsert(new Product
            {
               DeleteStatus=true,
               ProductName=p.ProductName,
               Description=p.Description,
               ImageUrl=p.ImageUrl,
               Price=p.Price,
               CategoryId=p.CategoryId
            });
            return Ok("Ürünler Başarıyla Eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO p)
        {
            _productService.TUpdate(new Product
            {
                DeleteStatus=true,
                Description= p.Description,
                ImageUrl= p.ImageUrl,
                Price= p.Price,
                ProductName= p.ProductName,
                ProductId= p.ProductId,
                CategoryId=p.CategoryId
            });
            return Ok("Ürünler Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var findProduct = _productService.TGetById(id);
            if (findProduct == null)
            {
                return NotFound();
            }
            else
            {
                _productService.TDelete(findProduct);
                return Ok("Ürünler Başarıyla Silindi.");
            }
        }
    }
}
