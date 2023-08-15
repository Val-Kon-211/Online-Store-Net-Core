using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using MyShop.Data.Repository;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class ShopCartController : Controller
    {
        public IAllCars _carRep;
        public readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        //вызов html-шаблона
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        //переадресация на другую страницу
        public RedirectToActionResult addToCart(int id)
        {
            //выбор нужного товара из списка товаров
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            //переадресация
            return RedirectToAction("Index");
        }
    }
}
