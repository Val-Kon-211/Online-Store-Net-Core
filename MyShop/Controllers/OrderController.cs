using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;          //обращение к интерфейсу
        private readonly ShopCart shopCart;             //обращение к ShopCart

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        //возвращает View, который может принимать данные с формы заполнения полей
        public IActionResult CheckOut()
        {
            return View();
        }

        //реакция на метод post
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            //берём товары из корзины и встраиваем в список
            shopCart.listShopItems = shopCart.getShopItems();

            //если нет товаров в корзине
            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","У Вас должны быть товары");
            }

            //если все данные в форме верны
            if (ModelState.IsValid)
            {
                //создаём заказ
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
