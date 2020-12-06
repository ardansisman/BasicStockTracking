using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Context;
using StokTakip.Models;
using StokTakip.Services;

namespace StokTakip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            try
            {
                var user = _userService.Query(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();

                if (user == null)
                {

                    return Json(new
                    {
                        success = 0,
                        message = "Kullanıcı adı veya şifre hatalı."
                    });
                }
                HttpContext.Session.SetString("isUserLogin", "true");
                return Json(new
                {
                    success = 1,
                    message = "Giriş Başarılı"
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = 0,
                    message = "Beklenmeyen bir hata oluştu."
                });
            }
        }

        public IActionResult Info()
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

    }
}
