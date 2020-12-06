using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StokTakip.Entities.Concrete;
using StokTakip.Models;
using StokTakip.Services;

namespace StokTakip.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService) 
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(_userService.GetAll());

        }
        public IActionResult Create()
        {
            return View(new User());
        }
        [HttpPost]
        public IActionResult Create(User userAddModel)
        {
            _userService.Create(userAddModel);
            return View("Index", _userService.GetAll());
        }


        public IActionResult Update(int Id)
        {
            var user = _userService.GetById(Id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User userUpdateModel)
        {
            var user = _userService.Update(userUpdateModel);
            return View("Index", _userService.GetAll());
        }
        public IActionResult Delete(int Id)
        {
            _userService.Delete(_userService.GetById(Id));
            return View("Index", _userService.GetAll());
        }


        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
