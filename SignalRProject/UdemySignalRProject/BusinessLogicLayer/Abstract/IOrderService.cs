using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
	public interface IOrderService:IGenericService<Order>
	{
		int TGetActiveOrderCount();
		int TGetTotalOrderCount();
		decimal TGetLastOrderPrice();

	}
}
