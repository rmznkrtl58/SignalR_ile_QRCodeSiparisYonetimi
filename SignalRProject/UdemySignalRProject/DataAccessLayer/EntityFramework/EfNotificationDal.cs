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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetNotificationByFalse()
        {
            using (var ent = new SignalRContext())
            {
                return ent.Notifications.Where(x => x.Status == false).ToList();
            }
        }

        public int GetNotificationCountByFalse()
        {
            using (var ent=new SignalRContext())
            {
                //Okunmayan bildirimlerin sayısı
                return ent.Notifications.Where(x => x.Status == false).Count();
            }
        }
    }
}
