using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StokTakip.Entities.Concrete;
using StokTakip.Services;

namespace StokTakip.Controllers
{
    
    public class BranchController : Controller
    {
        private readonly BranchService _branchService;
        public BranchController(BranchService branchService) 
        {
            _branchService = branchService;
        }
        public IActionResult Index()
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                return View(_branchService.GetAll());
            }
            return RedirectToAction("Login", "Home");
            
        }
        public IActionResult Create()
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                return View(new Branch());
            }
            return RedirectToAction("Login", "Home");
            
        }
        [HttpPost]
        public IActionResult Create(Branch branchAddModel)
        {
            _branchService.Create(branchAddModel);
            return View("Index", _branchService.GetAll());
        }
        public IActionResult Update(int Id)
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                var branch = _branchService.GetById(Id);
                return View(branch);
            }
            return RedirectToAction("Login", "Home");
            
        }
        [HttpPost]
        public IActionResult Update(Branch branchUpdateModel)
        {
            _branchService.Update(branchUpdateModel);
            return View("Index", _branchService.GetAll());
        }
        public IActionResult Delete(int Id)
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                var branch = _branchService.GetById(Id);
                _branchService.Delete(branch);
                return View("Index", _branchService.GetAll());
            }
            return RedirectToAction("Login", "Home");
            
        }
    }
}
