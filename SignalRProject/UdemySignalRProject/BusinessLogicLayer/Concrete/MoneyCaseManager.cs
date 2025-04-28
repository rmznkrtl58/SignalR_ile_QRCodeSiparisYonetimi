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
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public void TDelete(MoneyCase t)
		{
			throw new NotImplementedException();
		}

		public MoneyCase TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<MoneyCase> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public decimal TGetMoneyCaseTotalAmount()
		{
			return _moneyCaseDal.GetMoneyCaseTotalAmount();
		}

		public void TInsert(MoneyCase t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(MoneyCase t)
		{
			throw new NotImplementedException();
		}
	}
}
