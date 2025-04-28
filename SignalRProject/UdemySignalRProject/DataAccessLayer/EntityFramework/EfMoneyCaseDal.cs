﻿using DataAccessLayer.Abstract;
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
	public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
	{
		public EfMoneyCaseDal(SignalRContext context) : base(context)
		{
		}

		public decimal GetMoneyCaseTotalAmount()
		{
			using (var ent=new SignalRContext())
			{
				return ent.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
			}
		}
	}
}
