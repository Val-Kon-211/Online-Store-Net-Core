//Хранилище автомобилей
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        //---- Обращение к БД ----//
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        //------------------------//

        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.category);

        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavorite).Include(c => c.category);

        public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);
    }
}
