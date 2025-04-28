using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLogicLayer.Container
{
    public static class Extensions
    {
        //Web apide apilerimi test ederken api controllerimda 
        //Servicelerime bağlı olarak crud işlemlerini yapıyorduk
        //newlemelerden kurtarmak için AddScoped metodunu kullanacağız
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IReservationDal,EfReservationDal>();
            services.AddScoped<IReservationService,ReservationManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal,EfCategoryDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IDiscountDal, EfDiscountDal>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderService,OrderManager>();
            services.AddScoped<IOrderDetailsDal,EfOrderDetailDal>();
            services.AddScoped<IOrderDetailsService, OrderDetailsManager>();
            services.AddScoped<IMoneyCaseDal,EfMoneyCaseDal>();
            services.AddScoped<IMoneyCaseService,MoneyCaseManager>();
            services.AddScoped<IMenuTablesDal,EfMenuTableDal>();
            services.AddScoped<IMenuTableService,MenuTableManager>();
            services.AddScoped<ISliderDal, EfSliderDal>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IBasketDal, EfBasketDal>();
            services.AddScoped<INotificationDal,EfNotificationDal>();
            services.AddScoped<INotificationService,NotificationManager>();
            services.AddScoped<ICommunicationDal, EfCommunicationDal>();
            services.AddScoped<ICommunicationService, CommunicationManager>();
        }
    }
}
