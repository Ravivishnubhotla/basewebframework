using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPSMobile.Models
{
    public class LoginUserModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string LoginID { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }


        [Display(Name = "记住登录状态")]
        public bool SaveLoginStatus { get; set; }

        public bool ValidateUser()
        {
            return false;
        }
    }
}