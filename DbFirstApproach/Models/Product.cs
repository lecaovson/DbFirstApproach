using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DbFirstApproach.Models
{
    public class Product
    {
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage ="Price not null")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "DOP")]

        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Display(Name = "Category ID")]
        [Required(ErrorMessage ="Category not null")]
        public Nullable<long> CategoryID { get; set; }

        [Display(Name = "Brand ID")]
        
        public Nullable<long> BrandID { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public Nullable<decimal> Quanity { get; set; }

        public string Description { get; set; }

        public string DesImg { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}