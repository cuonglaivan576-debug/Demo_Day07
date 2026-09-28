using System;
using System.ComponentModel.DataAnnotations;

namespace Example05.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Tên đăng nhập phải có độ dài từ 3-20 ký tự")]
        public string UserName { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string FullName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Gõ lại mật khẩu")]
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password",
            ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không bỏ trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Display(Name = "Điện thoại")]
        [RegularExpression(@"^(0[35789])[0-9]{8}$",
            ErrorMessage = "Phải bắt đầu bằng 0 và dài 10-12 số")]
        public string Phone { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}