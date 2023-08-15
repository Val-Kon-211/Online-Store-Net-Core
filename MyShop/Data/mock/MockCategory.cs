using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.mock
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName = "электромобили", desc = "Современный вид транспорта"},
                    new Category { categoryName = "классические автомобили", desc = "Машины с двигателем внутреннего сгорания" }
                };
            }
        }
    }
}
