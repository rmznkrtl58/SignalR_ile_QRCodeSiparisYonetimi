using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
        public List<Reservation> GetListReservationByCondition(Expression<Func<Reservation,bool>>filter);
        void ConfirmReservation(int id);

    }
}
