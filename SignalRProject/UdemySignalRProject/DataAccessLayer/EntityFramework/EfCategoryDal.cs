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
    public class EfCategoryDal:GenericRepository<Category>,ICategoryDal
    {
        public EfCategoryDal(Concrete.SignalRContext context) : base(context)
        {

        }

		public int ActiveCategoryCount()
		{
			using (var ent=new SignalRContext())
			{
				return ent.Categories.Where(x => x.DeleteStatus == true).Count();
			}
		}

		public int GetCategoryCount()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Categories.Count();
			}
		}

		public int PassiveCategoryCount()
		{
			using (var ent = new SignalRContext())
			{
				return ent.Categories.Where(x => x.DeleteStatus == false).Count();
			}
		}
	}
}
