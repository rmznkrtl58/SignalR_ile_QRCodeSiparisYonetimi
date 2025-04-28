using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
	public interface IMenuTableService:IGenericService<MenuTable>
	{
		int TGetMenuTableCount();
		public void TChangeMenuTableStatusActive(int id);
		public void TChangeMenuTableStatusPassive(int id);
    }
}
