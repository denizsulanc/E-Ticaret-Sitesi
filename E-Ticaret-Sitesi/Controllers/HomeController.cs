using E_Ticaret_Sitesi.Entity;
using E_Ticaret_Sitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_Sitesi.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext(); //veri tabanı bağlantısının örneği
        // GET: Home
        public ActionResult Index()
        {
            return View(context.Products.Where(i => i.IsHome && i.IsApproved) //ikisi de true ise anasayfada görünecek
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId
                })
                .ToList());
        }
        public ActionResult Details(int id)
        {
            return View(context.Products.Where(i => i.Id == id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = context.Products.Where(i => i.IsApproved) //onaylanmış ise ürün listelenecek
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image == null ? "resimbulunamadi.jpg" : i.Image,
                    CategoryId = i.CategoryId
                }).AsQueryable();
            
            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler);
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(context.Categories.ToList());
        }
    }
}