using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{                //generate constructor
    public class EfAboutDal:GenericRepository<About>,IAboutDal
    {
        public EfAboutDal(Concrete.SignalRContext context) : base(context)
        {

        }
    }
}
