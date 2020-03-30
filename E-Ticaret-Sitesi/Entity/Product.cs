using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace E_Ticaret_Sitesi.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public double Price { get; set; }
        [DisplayName("Stok Durumu")]
        public int Stock { get; set; }
        [DisplayName("Ürün Resmi")]
        public string Image { get; set; }
        [DisplayName("Anasayfa Onayı")]
        public bool IsHome { get; set; }
        [DisplayName("Yayınlama Onayı")]
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; } //foreign key eğer int? yapsaydık bir kategori id girmek zorunda olmazdık nullable 
        public Category Category { get; set; }
    }
}