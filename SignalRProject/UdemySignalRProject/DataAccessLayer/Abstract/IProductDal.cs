using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        public List<Product> GetListProductWithCategory();
        public int GetProductCount();
        public int GetProductCountByHamburger();
        public int GetProductCountByDrinks();
		decimal GetProductPriceAvg();
		string GetProductByMaxPrice();
		string GetProductByMinPrice();
        decimal GetProductAvgPriceByHamburger();
        public List<Product> GetLast6Product();
        public Product GetProductPriceWithCondition(Expression<Func<Product, bool>> filter);
    }
}
