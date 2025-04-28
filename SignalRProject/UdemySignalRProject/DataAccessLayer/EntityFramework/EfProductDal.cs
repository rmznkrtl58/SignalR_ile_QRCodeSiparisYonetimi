using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DTOLayer.ProductDTOs;
using EntityLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetLast6Product()
        {
            using (var ent=new SignalRContext())
            {
				return ent.Products.OrderByDescending(x => x.ProductId).Take(6).ToList();
            }
        }

        public List<Product> GetListProductWithCategory()
        {
            //döneceğiz
            return null;
        }

		public decimal GetProductAvgPriceByHamburger()
		{
		    using (var ent = new SignalRContext()) 
			{
				return ent.Products.Where(x => x.CategoryId == (ent.Categories.Where(x => x.CategoryName == "Hamburger").Select(x => x.CategoryId).FirstOrDefault())).Average(z => z.Price);
			}
		}

		public string GetProductByMaxPrice()
		{
			using (var ent=new SignalRContext())
			{
				return ent.Products.Where(x => x.Price == (ent.Products.Max(x => x.Price))).Select(y => y.ProductName).FirstOrDefault();
			}
		}

		public string GetProductByMinPrice()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Products.Where(x => x.Price == (ent.Products.Min(x => x.Price))).Select(y => y.ProductName).FirstOrDefault();
			}
		}

		public int GetProductCount()
		{
            using (var ent=new SignalRContext())
            {
                return ent.Products.Count();
            }
		}

		public int GetProductCountByDrinks()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Products.Where(x => x.CategoryId == (ent.Categories.Where(y => y.CategoryName == "İçecek").Select(x => x.CategoryId).FirstOrDefault())).Count();
			}
		}

		public int GetProductCountByHamburger()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Products.Where(x => x.CategoryId == (ent.Categories.Where(y => y.CategoryName == "Hamburger").Select(x => x.CategoryId).FirstOrDefault())).Count();
			}
		}

		public decimal GetProductPriceAvg()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Products.Average(x => x.Price);
			}
		}

        public Product GetProductPriceWithCondition(Expression<Func<Product,bool>>filter)
        {
			using (var ent=new SignalRContext())
			{
				return ent.Products.Where(filter).FirstOrDefault();
			}
        }
    }
}
