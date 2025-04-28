using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities.Concrete;
using System.Linq.Expressions;


namespace BusinessLogicLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetById(int id)
        {
           return _productDal.GetById(id);
        }

        public List<Product> TGetLast6Product()
        {
            return _productDal.GetLast6Product();
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

		public decimal TGetProductAvgPriceByHamburger()
		{
			return _productDal.GetProductAvgPriceByHamburger();
		}

		public string TGetProductByMaxPrice()
		{
			return _productDal.GetProductByMaxPrice();
		}

		public string TGetProductByMinPrice()
		{
			return _productDal.GetProductByMinPrice();
		}

		public int TGetProductCount()
		{
			return _productDal.GetProductCount();
		}

		public int TGetProductCountByDrink()
		{
			return _productDal.GetProductCountByDrinks();
		}

		public int TGetProductCountByHamburger()
		{
			return _productDal.GetProductCountByHamburger();
		}

		public decimal TGetProductPriceAvg()
		{
			return _productDal.GetProductPriceAvg();
		}

        public Product TGetProductWithCondition(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
