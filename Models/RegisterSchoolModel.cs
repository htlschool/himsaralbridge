using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Svm.Models
{
    public class RegisterSchoolModel
    {
        shimlaEntities _db = new shimlaEntities();
        public RegisterSchoolModel()
        {
            _db = new shimlaEntities();
        }
        [Display(Name ="Select your School Website")]
        public virtual string school_website { get; set; }

        [Display(Name = "Or Select your School Code")]
        public virtual string school_code_drop { get; set; }

        [Required(ErrorMessage = "School Name Required")]
        [Display(Name = "School Name")]
        public string school_name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [Display(Name = "Email-ID")]
        public string user_name { get; set; }

        [Required(ErrorMessage ="Phone No. Required")]
        [Display(Name = "Phone No.")]      
        public string PhoneNo { get; set; }

        public string approve_status = "Requested";
        public int user_role = 3;
        public string school_code { get; set; }
        public int isActive = 1;

        public string SchoolWebsite { get; set; }
        public SelectList GetWebsites()
        {
            IEnumerable<SelectListItem> stateList = (from m in _db.tb_schoolregisetr select m).AsEnumerable().Select(m => new SelectListItem() { Text = m.school_website, Value = m.school_code });
            return new SelectList(stateList, "Value", "Text", school_website);
        }
        public SelectList GetSchoolCodes()
        {
            IEnumerable<SelectListItem> stateList = (from m in _db.tb_schoolregisetr select m).AsEnumerable().Select(m => new SelectListItem() { Text = m.school_code, Value = m.school_code });
            return new SelectList(stateList, "Value", "Text", school_code_drop);
        }
    }
}