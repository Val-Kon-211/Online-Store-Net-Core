using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        public IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                faveCars = _carRep.getFavCars
            };
            return View(homeCars);
        }
    }
}
