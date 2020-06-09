using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DbFirstApproach.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username không được để trống ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password không được để trống ")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm password không được để trống")]
        [Compare("Password",ErrorMessage ="Không giống với password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Email không được trống")]
       
        public string Email { get; set; }

        public string Mobile { get; set; }

        
        

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}