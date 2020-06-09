using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DbFirstApproach.Models
{
    public class Category
    {
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}