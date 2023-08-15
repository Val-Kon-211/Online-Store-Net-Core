//База данных. Заполнение данными

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            //Добавить данные в БД если таблицы пусты
            //Вариант 1: создать и вызвать функцию
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            //Вариант 2: прямое добавление элементов
            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "Самый популярный электромобиль",
                        longDesc = "Красивый, быстрый, самый лучший автомобиль от компании Tesla",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavorite = true,
                        available = true,
                        category = Categories["электромобили"]
                    },
                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Крутой и стабильный",
                        longDesc = "Неверояно крутой автомобиль проверенный временем",
                        img = "/img/nissan.jpg",
                        price = 40000,
                        isFavorite = false,
                        available = true,
                        category = Categories["электромобили"]
                    },
                    new Car
                    {
                        name = "Opel Ampera",
                        shortDesc = "Роскошное авто",
                        longDesc = "Данный автомобиль подходит для самых крутых",
                        img = "/img/opel.jpg",
                        price = 30000,
                        isFavorite = true,
                        available = true,
                        category = Categories["электромобили"]
                    },
                    new Car
                    {
                        name = "Renault Logan",
                        shortDesc = "Семейный и практичный",
                        longDesc = "Очень семейный и очень надёжный, а практичный что тёща точно одобрит",
                        img = "/img/renault.jpg",
                        price = 10000,
                        isFavorite = true,
                        available = true,
                        category = Categories["классические автомобили"]
                    },
                    new Car
                    {
                        name = "Subaru XV",
                        shortDesc = "Просто крутой",
                        longDesc = "Крутой, что звёзды на небе будут меркнуть перед ним",
                        img = "/img/subaru.jpg",
                        price = 20000,
                        isFavorite = true,
                        available = true,
                        category = Categories["классические автомобили"]
                    }
                 );
            }

            content.SaveChanges();  //сохранение изменений
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "электромобили", desc = "Современный вид транспорта"},
                        new Category {categoryName = "классические автомобили", desc = "Машины с двигателем внутреннего сгорания" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}
