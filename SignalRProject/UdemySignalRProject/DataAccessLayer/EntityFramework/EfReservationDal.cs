using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities.Concrete;
using System.Linq.Expressions;


namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public EfReservationDal(SignalRContext context) : base(context)
        {
        }

        public void ConfirmReservation(int id)
        {
            using (var ent = new SignalRContext() { })
            {
                var findReservation = ent.Reservations.Find(id);
                findReservation.ReservationStatus = true;
                findReservation.DeleteStatus = true;
                ent.SaveChanges();
            }
        }

        List<Reservation> IReservationDal.GetListReservationByCondition(Expression<Func<Reservation, bool>> filter)
		{
			using (var ent=new SignalRContext())
			{
				return ent.Reservations.Where(filter).ToList();
			}
		}

    }
}
