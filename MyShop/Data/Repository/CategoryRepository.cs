using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        //---- Обращение к БД ----//
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        //------------------------//

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
