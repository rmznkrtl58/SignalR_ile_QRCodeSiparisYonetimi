using DataAccessLayer.Abstract;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
		List<Reservation> TGetListReservationByConfirmation();
		List<Reservation> TGetListReservationByPendingConfirmation();
        void TConfirmReservation(int id);
    }
}
