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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TDelete(Slider t)
        {
            throw new NotImplementedException();
        }

        public Slider TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Slider> TGetListAll()
        {
           return _sliderDal.GetListAll();
        }

        public void TInsert(Slider t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Slider t)
        {
            throw new NotImplementedException();
        }
    }
}
