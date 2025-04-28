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
	public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTablesDal
	{
		public EfMenuTableDal(SignalRContext context) : base(context)
		{
		}
        public void ChangeMenuTableStatusActive(int id)
        {   //Masa Dolu
            using (var ent = new SignalRContext())
            {
               var findMenuTable=ent.MenuTables.Where(x => x.TableId == id).FirstOrDefault();
               findMenuTable.Status = true;
               ent.SaveChanges();
            }
        }

        public void ChangeMenuTableStatusPassive(int id)
        {   //Masa Boş
            using (var ent = new SignalRContext())
            {
                var findMenuTable = ent.MenuTables.Where(x => x.TableId == id).FirstOrDefault();
                findMenuTable.Status = false;
                ent.SaveChanges();
            }
        }
        public int GetMenuTableCount()
		{
			using (var ent=new SignalRContext())
			{
				return ent.MenuTables.Count();
			}
		}
	}
}
