using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Ticaret_Sitesi.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //ürünleri eklemeden önce ilk olarak kategorilerin girmesi gerekiyor 
            List<Category> kategoriler = new List<Category>() //var ile de tanımlama yapabilirdik
            {
                new Category() { Name = "kamera", Description = "Kamera Ürünleri" },
                new Category() { Name = "Bilgisayar", Description = "Bilgisayar Ürünleri" },
                new Category() { Name = "Elektronik", Description = "Elektronik Ürünleri" },
                new Category() { Name = "Telefon", Description = "Telefon Ürünleri" },
                new Category() { Name = "Beyaz Eşya", Description = "Beyaz Eşya Ürünleri" },
                new Category() { Name = "Müzik", Description = "Müzik Aletleri" },
                new Category() { Name = "Mobilya", Description = "Mobilya Ürünleri" }
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }

            context.SaveChanges();

            List<Product> urunler = new List<Product>()
            {
                new Product(){ Name="INSTAX", Description="Kaliteli bir üründür", Price=2000, Stock=100, Image="instax.png", IsHome=true, IsApproved=true, CategoryId=1 },
                new Product(){ Name="SONY", Description="Profesyonel çekimler için ideal bir üründür", Price=2500, Stock=100, Image="sony.png", IsHome=true, IsApproved=true, CategoryId=1 },
                new Product(){ Name="DELL LAPTOP", Description="Yazılımcılar için en iyi laptop", Price=4000, Stock=100, Image="dell.jpg", IsHome=true, IsApproved=true, CategoryId=2 },
                new Product(){ Name="CASPER LAPTOP", Description="En kaliteli oyunları oynamanızı sağlar", Price=3500, Stock=100, Image="casper.jpg", IsHome=true, IsApproved=true, CategoryId=2 },
                new Product(){ Name="TELEVİZYON", Description="Yüksek çözünürlüklüdür", Price=5000, Stock=100, Image="televizyon.jpg", IsHome=true, IsApproved=true, CategoryId=3 },
                new Product(){ Name="PLAYSTATION", Description="Son model sony playstation ürünüdür", Price=4500, Stock=100, Image="playstation.jpg", IsHome=true, IsApproved=true, CategoryId=3 },
                new Product(){ Name="IPHONE", Description="Çok hızlı menü yapısına sahiptir", Price=10000, Stock=100, Image="iphone.jpg", IsHome=true, IsApproved=true, CategoryId=4 },
                new Product(){ Name="ASUS", Description="Tek şarj ile en uzun süreli kullanım", Price=2000, Stock=100, Image="asus.jpg", IsHome=true, IsApproved=true, CategoryId=4 },
                new Product(){ Name="SAMSUNG", Description="Kalite bakımından en iyisi", Price=2750, Stock=100, Image="samsung.jpg", IsHome=true, IsApproved=false, CategoryId=4 },
                new Product(){ Name="BUZDOLABI", Description="Geniş iç hacime sahiptir", Price=6000, Stock=100, Image="buzdolabi.png", IsHome=true, IsApproved=true, CategoryId=5 },
                new Product(){ Name="ÇAMAŞIR MAKİNESİ", Description="Tek seferde bütün çamaşırlarınızı yıkamanızı sağlar", Price=5500, Stock=100, Image="camasirmakinesi.jpg", IsHome=true, IsApproved=true, CategoryId=5 },
                new Product(){ Name="BULAŞIK MAKİNESİ", Description="Çok dayanıklı bir üründür", Price=4600, Stock=100, Image="bulasikmakinesi.jpg", IsHome=true, IsApproved=false, CategoryId=5 },
                new Product(){ Name="KOLTUK TAKIMI", Description="Rahat yapısı ile ailenizle keyifli vakitler geçireceğiniz koltuk takımı", Price=4000, Stock=100, Image="koltuktakimi.jpg", IsHome=true, IsApproved=true, CategoryId=7 },
                new Product(){ Name="ÇALIŞMA MASASI", Description="Şık görüntüye sahip çalışma masası", Price=2000, Stock=100, Image="calismamasasi.jpg", IsHome=true, IsApproved=true, CategoryId=7 },
                new Product(){ Name="YEMEK MASASI", Description="Geniş aileler için uygundur", Price=2000, Stock=100, IsHome=false, IsApproved=true, CategoryId=7 },
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges(); //bu kod çalıştığı anda eklediğimiz bilgiler veritabanına aktarılır

            base.Seed(context);
        }
    }
}