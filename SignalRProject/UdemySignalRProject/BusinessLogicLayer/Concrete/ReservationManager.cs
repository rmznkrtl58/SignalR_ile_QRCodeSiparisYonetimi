using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void TConfirmReservation(int id)
        {
            _reservationDal.ConfirmReservation(id);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetById(int id)
        {
           return _reservationDal.GetById(id);
        }

        public List<Reservation> TGetListAll()
        {
           return _reservationDal.GetListAll();
        }

		public List<Reservation> TGetListReservationByConfirmation()
		{
           return _reservationDal.GetListReservationByCondition(x=>x.ReservationStatus==true&&x.DeleteStatus==true);
		}

		public List<Reservation> TGetListReservationByPendingConfirmation()
		{
           return _reservationDal.GetListReservationByCondition(x => x.ReservationStatus == false && x.DeleteStatus == true);
		}

		public void TInsert(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
