using FashionGo.Models.Entities;
using FashionGo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionGo.Models.Dao
{
    public static class ProductCategoryDao
    {

        public static ApplicationDbContext db = new ApplicationDbContext();

        public static SelectList listCategory(int? selected = null, int exclude_id = -1)
        {
            //return new SelectList(new[] { new SelectListItem() { Text = "No Category", Value = "0" } });
            
            return new SelectList(db.ProductCategories.Where(p => p.CatId != exclude_id), "CatId", "Name", selected);
        }

        public static List<int> ChildCategoryIds(int _parentId)
        {
            List<int> ListCats = new List<int>();
            ListCats.Add(_parentId);

            foreach (var cat in db.ProductCategories.Where(p=>p.ParentId == _parentId).ToList())
            {
                int _catid = Convert.ToInt32(cat.CatId);
                ListCats.Add(_catid);
            }

            return ListCats;
        }

        public static List<ProductCategory> ChildCategories(this ProductCategory parentCategory)
        {
            return db.ProductCategories.Where(c => c.ParentId == parentCategory.CatId).OrderBy(c=>c.Name).ToList();
        }

        public static List<Product> AllProducts(this ProductCategory category, int Limit = 100)
        {
            var catids = ChildCategoryIds(category.CatId);
            var products = db.Products
                                .Where(p => p.Actived == true)
                                .Where(p => catids.Contains(p.CatId.Value))
                                .OrderBy(p => p.Name)
                                .Take(Limit)
                                .ToList();
            return products;
        }

        public static int CountProducts(this ProductCategory category)
        {
            var catids = ChildCategoryIds(category.CatId);
            return db.Products
                                .Where(p => p.Actived == true)
                                .Where(p => catids.Contains(p.CatId.Value))
                                .Count();
        }
    }
}