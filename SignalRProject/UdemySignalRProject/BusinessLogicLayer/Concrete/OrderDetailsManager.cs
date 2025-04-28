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
	public class OrderDetailsManager : IOrderDetailsService
	{
		private readonly IOrderDetailsDal _orderDetailsDal;

		public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
		{
			_orderDetailsDal = orderDetailsDal;
		}

		public void TDelete(OrderDetail t)
		{
			_orderDetailsDal.Delete(t);
		}

		public OrderDetail TGetById(int id)
		{
			return _orderDetailsDal.GetById(id);
		}

		public List<OrderDetail> TGetListAll()
		{
			return _orderDetailsDal.GetListAll();
		}

		public void TInsert(OrderDetail t)
		{
			_orderDetailsDal.Insert(t);
		}

		public void TUpdate(OrderDetail t)
		{
			_orderDetailsDal.Update(t);
		}
	}
}
