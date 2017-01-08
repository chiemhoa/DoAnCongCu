using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webtruyen.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập Tên đăng nhập")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời nhập Mật khẩu")]
        public string Passwork { set; get; }
        public bool RememberMe { set; get; }
    }
}