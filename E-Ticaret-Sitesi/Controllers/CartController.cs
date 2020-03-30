using E_Ticaret_Sitesi.Entity;
using E_Ticaret_Sitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret_Sitesi.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id); //eğer bu product veri tabanında varsa

            if (product != null)
            {
                GetCart().AddProduct(product, 1); //varsayılan olarak 1 eleman eklettiriyorum
            }

            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id); //eğer bu product veri tabanında varsa

            if (product != null)
            {
                GetCart().DeleteProduct(product); //varsayılan olarak 1 eleman eklettiriyorum
            }

            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            //Session'ları siteyi ziyaret eden kişiye özel oluşturulan depolar olarak düşünebiliriz
            var cart = (Cart)Session["Cart"]; //Session obje türünde olduğu için Cart class'ına çevirdim

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid) //Form eksiksiz olarak dolduruldu
            {
                //Siparişi veritabanına kayıt et
                //cart'ı sıfırla
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity); //Kullanıcının girdiği bilgilerle Checkout View'ini aç
            }
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random()).Next(11111, 999999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Waiting;
            order.UserName = User.Identity.Name;

            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;
            order.OrderLines = new List<OrderLine>();

            foreach (var cl in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = cl.Quantity;
                orderline.Price = cl.Quantity * cl.Product.Price;
                orderline.ProductId = cl.Product.Id;

                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}