using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.BasketDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketsController(IBasketService basketService, IProductService productService = null)
        {
            _basketService = basketService;
        }
        [HttpGet("GetBasketByMenuTableNumber/{id}")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {    //solide aykırı bakacağım
                using var ent =new SignalRContext();
              var values=ent.Baskets.Include(x => x.Product).Where(x => x.MenuTableId == id).Select(x => new ResultBasketByMenuTableDTO
                {
                    BasketId = x.BasketId,
                    MenuTableId = x.MenuTableId,
                    Count = x.Count,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.Product.ProductName,
                    TotalPrice = x.TotalPrice
                }).ToList();
            if (values == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDTO b)
        {
            using (var ent=new SignalRContext())
            {
                _basketService.TInsert(new Basket()
                {
                    MenuTableId = b.MenuTableId,
                    Count = 1,
                    Price = ent.Products.Where(x=>x.ProductId==b.ProductId).Select(x=>x.Price).FirstOrDefault(),
                    ProductId = b.ProductId,
                    TotalPrice = b.TotalPrice
                });
            }
            return Ok("Ürünler Başarıyla Sepete Eklendi!");
        }
        [HttpDelete]
        public IActionResult DeleteBasket(int id)
        {
            var findProductInCart=_basketService.TGetById(id);
            if (findProductInCart == null)
            {
                return NotFound();
            }
            else
            {
                _basketService.TDelete(findProductInCart);
                return Ok("Sepetteki Ürünler Başarıyla Silindi");
            }
        }
    }
}
