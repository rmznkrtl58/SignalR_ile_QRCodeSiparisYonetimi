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
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTablesDal _menuDal;

		public MenuTableManager(IMenuTablesDal menuDal)
		{
			_menuDal = menuDal;
		}

        public void TChangeMenuTableStatusActive(int id)
        {
			_menuDal.ChangeMenuTableStatusActive(id);
        }
        public void TChangeMenuTableStatusPassive(int id)
        {
			_menuDal.ChangeMenuTableStatusPassive(id);
        }
        public void TDelete(MenuTable t)
		{
			_menuDal.Delete(t);
		}

		public MenuTable TGetById(int id)
		{
			return _menuDal.GetById(id);
		}

		public List<MenuTable> TGetListAll()
		{
			return _menuDal.GetListAll();
		}

		public int TGetMenuTableCount()
		{
			return _menuDal.GetMenuTableCount();
		}

		public void TInsert(MenuTable t)
		{
			_menuDal.Insert(t);
		}

		public void TUpdate(MenuTable t)
		{
			_menuDal.Update(t);
		}
	}
}
