using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Example05.Models.DataModels;
using Example05.Models.ViewModels;

namespace Example05.Controllers
{
    public class MembersController : Controller
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
        public IActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    UserName = register.UserName,
                    FullName = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,
                    Birthday = register.Birthday
                };

                members.Add(m);

                return RedirectToAction("Index");
            }

            return View(register);
        }
    }
}