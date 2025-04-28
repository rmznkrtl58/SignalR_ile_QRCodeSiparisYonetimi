using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
		int TGetProductCount();
		int TGetProductCountByHamburger();
		int TGetProductCountByDrink();
		decimal TGetProductPriceAvg();
		string TGetProductByMaxPrice();
		string TGetProductByMinPrice();
		decimal TGetProductAvgPriceByHamburger();
        public List<Product> TGetLast6Product();
		public Product TGetProductWithCondition(Expression<Func<Product, bool>> filter);
    }
}
