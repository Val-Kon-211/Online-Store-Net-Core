//Модель товара в корзине

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public int price { get; set; }
        public string ShopCarId { get; set; }   //ID товара в корзине
    }
}
