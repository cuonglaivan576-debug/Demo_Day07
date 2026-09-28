using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Example05.Models.DataModels;

namespace Example05.Controllers
{
    public class MemberController : Controller
    {
        public static readonly List<Member> members =
            new List<Member>();

        public IActionResult Index()
        {
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            string msg = "";
            bool validate = true;

            // 1. Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(member.UserName)
                || member.UserName.Length < 3
                || member.UserName.Length > 20)
            {
                msg += "<li>Tên đăng nhập phải có độ dài từ 3-20 ký tự</li>";
                validate = false;
            }

            // 2. Kiểm tra Email
            string patternemail =
                @"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

            if (string.IsNullOrWhiteSpace(member.Email)
                || !Regex.IsMatch(
                    member.Email,
                    patternemail,
                    RegexOptions.IgnoreCase))
            {
                msg += "<li>Email không đúng định dạng</li>";
                validate = false;
            }

            // 3. Kiểm tra tuổi
            if (member.Birthday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }

            // 4. Kiểm tra số điện thoại
            string patternphone = @"^(0[35789])[0-9]{8}$";

            if (string.IsNullOrWhiteSpace(member.Phone)
                || !Regex.IsMatch(member.Phone, patternphone))
            {
                msg += "<li>Số điện thoại không hợp lệ</li>";
                validate = false;
            }

            // 5. Nếu hợp lệ
            if (validate)
            {
                member.MemberId = Guid.NewGuid().ToString();

                members.Add(member);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg =
                    "<div class='alert alert-danger'>"
                    + "<ul>" + msg + "</ul>"
                    + "</div>";

                return View(member);
            }
        }
    }
}