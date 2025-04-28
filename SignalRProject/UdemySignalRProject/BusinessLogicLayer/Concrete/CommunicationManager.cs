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
    public class CommunicationManager : ICommunicationService
    {
        private readonly ICommunicationDal _communicationDal;

        public CommunicationManager(ICommunicationDal communicationDal)
        {
            _communicationDal = communicationDal;
        }

        public void TDelete(communication t)
        {
            _communicationDal.Delete(t);
        }

        public communication TGetById(int id)
        {
            return _communicationDal.GetById(id);
        }
        public List<communication> TGetListAll()
        {
            return _communicationDal.GetListAll();
        }

        public void TInsert(communication t)
        {
           _communicationDal.Insert(t);
        }

        public void TUpdate(communication t)
        {
            _communicationDal.Update(t);
        }
    }
}
