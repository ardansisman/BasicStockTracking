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
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                return View(_productService.GetAll());
            }
            return RedirectToAction("Login", "Home");
            

        }
        [HttpPost]
        public IActionResult GetById(int productId)
        {
            var product = _productService.GetById(productId);
            if (product != null)
            {
                return Json(new
                {
                    success = 1,
                    message = "Giriş Başarılı",
                    productname = product.Name,
                    stock = product.Stock
                });
            }
            else
            {
                return Json(new
                {
                    success = 0,
                    message = "Ürün bulunamadı"
                });
            }

        }
        public IActionResult Create()
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                return View(new Product());
            }
            return RedirectToAction("Login", "Home");
           
        }
        [HttpPost]
        public IActionResult Create(Product productAddModel)
        {
            _productService.Create(productAddModel);
            return View("Index", _productService.GetAll());
        }
        public IActionResult Update(int Id)
        {
            var product = _productService.GetById(Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product productUpdateModel)
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                _productService.Update(productUpdateModel);
                return View("Index", _productService.GetAll());
            }
            return RedirectToAction("Login", "Home");
            
        }
        [HttpPost]
        public IActionResult StockUpdate(int productId, int stokGiris)
        {
            var product = _productService.GetById(productId);
            if (product != null)
            {


                if (stokGiris != 0)
                {
                    product.Stock += stokGiris;
                }
                _productService.Update(product);

                return Json(new
                {
                    success = 1,
                    message = "Stok güncelleme başarılı"
                });
            }
            else
            {
                return Json(new
                {
                    success = 0,
                    message = "Ürün bulunamadı"
                });
            }
        }
        public IActionResult Delete(int Id)
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                var product = _productService.GetById(Id);
                _productService.Delete(product);
                return View("Index", _productService.GetAll());
            }
            return RedirectToAction("Login", "Home");
           
        }

    }
}
