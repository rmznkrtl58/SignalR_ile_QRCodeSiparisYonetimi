using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface INotificationService:IGenericService<Notification>
    {
      int TGetNotificationCountByFalse();
      List<Notification>TGetNotificationByFalse();
    }
}
