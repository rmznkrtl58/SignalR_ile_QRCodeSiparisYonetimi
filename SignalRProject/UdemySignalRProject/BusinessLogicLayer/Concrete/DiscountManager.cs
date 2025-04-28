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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TDelete(Discount t)
        {
           _discountDal.Delete(t);
        }

        public Discount TGetById(int id)
        {
           return _discountDal.GetById(id);
        }

        public List<Discount> TGetListAll()
        {
           return _discountDal.GetListAll();
        }

        public void TInsert(Discount t)
        {
           _discountDal.Insert(t);
        }

        public void TUpdate(Discount t)
        {
           _discountDal.Update(t);
        }
    }
}
