using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Svm.Models
{
    public class LoginModel
    {
        shimlaEntities _db = new shimlaEntities();
        public LoginModel()
        {
            _db = new shimlaEntities();
        }

        [Required(ErrorMessage = "User Name Required")]
        [Display(Name = "User Name")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string user_pwd { get; set; }

    }
}