using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DbFirstApproach.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="Username khong duoc de trong")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password khong duoc de trong")]
        public string Password { get; set; }
    }
}