//Модель корзины

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class ShopCart
    {
        //---- Обращение к БД ----//
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        //------------------------//

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        //проверка, создана ли уже крзина; если нет - создаёт; возвращает корзину
        public static ShopCart GetCart(IServiceProvider services)
        {
            //создание сессии
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //переменная с таблицами БД
            var context = services.GetService<AppDBContent>();
            //устанавливаем значение из сессии; если этого значение нет - создаём новый идентификатор
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            
            //полученный/созданный id устанавливаем как значение сессии и передаём ему значение
            session.SetString("CarId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        //добавление товаров в корзину
        public void AddToCart(Car car)
        {
            this.appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCarId = ShopCartId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        //отображение товаров в корзине
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCarId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
