using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public int GetActiveOrderCount()
		{
			using (var ent=new SignalRContext())
			{

				return ent.Orders.Where(x => x.Description == "Müşteri Ödeme Yaptı.").Count();
			}
		}

		public decimal GetLastOrderPrice()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Orders.OrderByDescending(x => x.OrderId).Select(x => x.TotalPrice).Take(1).FirstOrDefault();
			}
		}

		public int GetTotalOrderCount()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Orders.Count();
			}
		}
	}
}
