using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
	public class OrderDetail
	{
        public int OrderDetailId { get; set; }
        //ürünümle ilişkili
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }//kaç tane almış
        public decimal UnitPrice { get; set; }//birim fiyat
        public decimal TotalPrice { get; set; }//adet*birim fiyat
        //ilişki sipariş tablosuyla ilişki
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
