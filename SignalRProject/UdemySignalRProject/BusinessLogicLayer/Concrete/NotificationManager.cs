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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> TGetNotificationByFalse()
        {
            return _notificationDal.GetNotificationByFalse();
        }

        public void TDelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetListAll()
        {
          return  _notificationDal.GetListAll();
        }

        public int TGetNotificationCountByFalse()
        {
            return _notificationDal.GetNotificationCountByFalse(); 
        }

        public void TInsert(Notification t)
        {
            _notificationDal.Insert(t);
        }

        public void TUpdate(Notification t)
        {
           _notificationDal.Update(t);
        }
    }
}
