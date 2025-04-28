using Microsoft.AspNetCore.Mvc;
using QRCoder;


namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
			[HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream=new MemoryStream())
            {
                //bir quar oluşturma nesnesi oluşturdum
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                //value parametremden gelen veriyi "Q" seviyesinde
                //QRCode formatında Oluştur
                QRCodeData squareQRCodeData = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                PngByteQRCode qrCode=new PngByteQRCode(squareQRCodeData);
                byte[] qrCodeBytes = qrCode.GetGraphic(10);
				ViewBag.QRCodeImage = "data:image/png;base64,"+Convert.ToBase64String(qrCodeBytes);
				//bitmap->bir şeyi resmetmek,çizmek
				//squareQRCode'dan gelen değeri 10 bitlik bir
				//grafik (görsel) haline getir
				//using (Bitmap image=squareQRCode.GetGraphic(10))//10 bitlik görsel
				//{
				//    //image'dan gelen değeri png formatında kaydet
				//    image.Save(memoryStream, ImageFormat.Png);
				//    ViewBag.QRCodeImage = "data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
				//}

			}
			return View();
        }
    }
}
