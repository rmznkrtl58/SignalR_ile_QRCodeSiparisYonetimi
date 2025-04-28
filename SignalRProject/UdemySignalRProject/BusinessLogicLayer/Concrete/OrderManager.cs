using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public decimal TGetLastOrderPrice()
		{
		  return _orderDal.GetLastOrderPrice();
		}

		public void TDelete(Order t)
		{
			_orderDal.Delete(t);
		}

		public int TGetActiveOrderCount()
		{
			return _orderDal.GetActiveOrderCount();
		}

		public Order TGetById(int id)
		{
			return _orderDal.GetById(id);
		}

		public List<Order> TGetListAll()
		{
			return _orderDal.GetListAll();
		}

		public int TGetTotalOrderCount()
		{
			return _orderDal.GetTotalOrderCount();
		}

		public void TInsert(Order t)
		{
			_orderDal.Insert(t);
		}

		public void TUpdate(Order t)
		{
			_orderDal.Update(t);
		}
	}
}
