using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{   //serverımız olan yer yani real time işlemleri yazacağımız
	//yer burası
	public class SignalRHub:Hub
	{
		//burada olacak işlemler yazılır ve bu methotları client tarafında
		//Invoke ile çağırırız ve anlık işlemler gerçekleşir
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menutableService;
		private readonly IReservationService _reservationService;
		private readonly INotificationService _notificationService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menutableService, IReservationService reservationService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menutableService = menutableService;
            _reservationService = reservationService;
            _notificationService = notificationService;
        }

        public async Task SendStatistics()//client'ta invoke olarak çağırcam
		{
			//Anlık kategori sayısı
			var value = _categoryService.TGetCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount",value);
			//client tarafında ReceiveCategoryCount değerimiz ile birlikte "on" olarak çağırcam
			
			//Anlık Ürün sayısı
			var value2 = _productService.TGetProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			//Anlık Aktif kategori sayısı
			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);
			//Anlık Pasif kategori sayısı
			var value4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);
			//Anlık Hamburger kategorisine sahip ürün sayısı
			var value5 = _productService.TGetProductCountByHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByHamburger", value5);
			//Anlık İçecek kategorisine sahip ürün sayısı
			var value6 = _productService.TGetProductCountByDrink();
			await Clients.All.SendAsync("ReceiveProductCountByDrink", value6);
			//Anlık ürünlerin toplam ortalaması
			var value7 = _productService.TGetProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString()+" ₺");
			//Anlık en yüksek fiyatlı ürün
			var value8 = _productService.TGetProductByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductByMaxPrice", value8);
			//Anlık en Düşük fiyatlı ürün
			var value9 = _productService.TGetProductByMinPrice();
			await Clients.All.SendAsync("ReceiveProductByMinPrice", value9);
			//Anlık Hamburger kategorili ürünlerin ortalama fiyatı
			var value10 = _productService.TGetProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10 + " ₺");
			//Anlık toplam sipariş sayısı
			var value11 = _orderService.TGetTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);
			//Anlık toplam Aktif sipariş sayısı
			var value12 = _orderService.TGetActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);
			//Anlık Son sipariş tutarı
			var value13 = _orderService.TGetLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13 + " ₺");
			//Anlık Bugünki kazanç tutarı
			//var value12 = _orderService.TGetActiveOrderCount();
			//await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);
			//Toplam Kasadaki Tutar
			var value14 = _moneyCaseService.TGetMoneyCaseTotalAmount();
			await Clients.All.SendAsync("MoneyCaseTotalAmount", value14 + " ₺");
			//Toplam Masa sayısı
			var value15 = _menutableService.TGetMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value15);
		}
		public async Task SendProgress()
		{
			var value=_moneyCaseService.TGetMoneyCaseTotalAmount();
			await Clients.All.SendAsync("RecieveTGetMoneyCaseTotalAmount",value+" ₺");
			var value2 = _orderService.TGetLastOrderPrice();
			await Clients.All.SendAsync("TReceiveLastOrderPrice", value2 + " ₺");
			var value3 = _orderService.TGetActiveOrderCount();
			await Clients.All.SendAsync("TReceiveActiveOrderCount", value3);
			var value4 = _orderService.TGetActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value4);
			var value5 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value5);
			var value6 = _productService.TGetProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value6);

		}
		public async Task GetReservationList()
		{
			var values = _reservationService.TGetListAll();
			await Clients.All.SendAsync("ReceiveReservationList",values);
		}
		public async Task SendNotificationCountByFalse() 
		{
			int value = _notificationService.TGetNotificationCountByFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var values = _notificationService.TGetNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationByFalse", values);
        }
		public async Task GetMenuTableByStatus()
		{
			var values = _menutableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveGetMenuTableByStatus",values);
		}
		public async Task SendMessage(string user,string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
		public static int clientCount { get; set; } = 0;
        public override async Task OnConnectedAsync()
        {   //Cliente bağlı olan kullanıcı sayısını verir
			clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			//bağlantısı kopan kullanıcı sayısını verir
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnDisconnectedAsync(exception);
			//exception herhangi bir hata anında yapılan işlemdir
        }
    }
}
