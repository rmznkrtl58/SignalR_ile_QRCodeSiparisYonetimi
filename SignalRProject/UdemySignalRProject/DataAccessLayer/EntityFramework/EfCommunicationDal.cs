using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities.Concrete;


namespace DataAccessLayer.EntityFramework
{
    public class EfCommunicationDal : GenericRepository<communication>, ICommunicationDal
    {
        public EfCommunicationDal(SignalRContext context) : base(context)
        {
        }
    }
}
