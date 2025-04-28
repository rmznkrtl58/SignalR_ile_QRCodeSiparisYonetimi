using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        public List<Basket> TGetBasketByMenuTableNumber(int id);
    }
}
