using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.mock
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car {
                        name = "Tesla", 
                        shortDesc = "Самый популярный электромобиль", 
                        longDesc = "Красивый, быстрый, самый лучший автомобиль от компании Tesla", 
                        img = "/img/tesla.jpg", 
                        price = 45000, 
                        isFavorite = true, 
                        available = true, 
                        category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        name = "Nissan Leaf", 
                        shortDesc = "Крутой и стабильный", 
                        longDesc = "Неверояно крутой автомобиль проверенный временем", 
                        img = "/img/nissan.jpg", 
                        price = 40000, 
                        isFavorite = false, 
                        available = true, 
                        category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        name = "Opel Ampera", 
                        shortDesc = "Роскошное авто", 
                        longDesc = "Данный автомобиль подходит для самых крутых", 
                        img = "/img/opel.jpg", 
                        price = 30000, 
                        isFavorite = true, 
                        available = true, 
                        category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        name = "Renault Logan", 
                        shortDesc = "Семейный и практичный", 
                        longDesc = "Очень семейный и очень надёжный, а практичный что тёща точно одобрит", 
                        img = "/img/renault.jpg", 
                        price = 10000, 
                        isFavorite = true, 
                        available = true, 
                        category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        name = "Subaru XV", 
                        shortDesc = "Просто крутой", 
                        longDesc = "Крутой, что звёзды на небе будут меркнуть перед ним", 
                        img = "/img/subaru.jpg", 
                        price = 20000, 
                        isFavorite = true, 
                        available = true, 
                        category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int CarId)
        {
            throw new NotImplementedException();
        }
    }
}
