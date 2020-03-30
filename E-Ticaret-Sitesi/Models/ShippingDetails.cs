﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Ticaret_Sitesi.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen mahhalle giriniz.")]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
    }
}