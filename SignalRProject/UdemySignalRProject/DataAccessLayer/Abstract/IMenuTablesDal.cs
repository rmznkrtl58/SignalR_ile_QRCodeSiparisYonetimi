using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IMenuTablesDal:IGenericDal<MenuTable>
	{
		int GetMenuTableCount();
		void ChangeMenuTableStatusActive(int id);
		void ChangeMenuTableStatusPassive(int id);
	}
}
