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
    public class DeliveryController : Controller
    {
        private readonly DeliveryService _deliveryService;
        private readonly ProductService _productService;
        private readonly BranchService _branchService;
        public DeliveryController(DeliveryService deliveryService, ProductService productService, BranchService branchService) 
        {
            _deliveryService = deliveryService;
            _productService = productService;
            _branchService = branchService;
        }
        public IActionResult Index()
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                var deliveries = _deliveryService.GetStockList();

                return View(deliveries);
            }
            return RedirectToAction("Login", "Home");
           

        }
        public IActionResult Create()
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                var model = new DeliveryAddModel();
                model.BranchList = _branchService.GetAll();
                model.ProductList = _productService.GetAll();
                return View(model);
            }
            return RedirectToAction("Login", "Home");
            
        }
        [HttpPost]
        public IActionResult Create(Delivery delivery)
        {
            _deliveryService.Create(delivery);
            var product = _productService.GetById(delivery.ProductId);
            product.Stock -= delivery.Piece;
            _productService.Update(product);
            return View("Index", _deliveryService.GetStockList());
        }
        public IActionResult Update(int Id)
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                var model = new DeliveryUpdateModel();
                model.BranchList = _branchService.GetAll();
                model.ProductList = _productService.GetAll();
                model.Delivery = _deliveryService.GetById(Id);
                return View(model);
            }
            return RedirectToAction("Login", "Home");
            
        }
        [HttpPost]
        public IActionResult Update(Delivery delivery)
        {
            var product = _productService.GetById(delivery.ProductId);
            var branch = _branchService.GetById(delivery.BranchId);
            delivery.Product = product;
            delivery.Branch = branch;
            
            if (product.Stock > delivery.Piece)
            {
                var deliveryDB = _deliveryService.GetById(delivery.Id);
                if (delivery.Piece - deliveryDB.Piece < 0)
                {
                    product.Stock += (delivery.Piece - deliveryDB.Piece);
                }
                else
                {
                    product.Stock -= (delivery.Piece - deliveryDB.Piece);
                }
                _productService.Update(product);
                deliveryDB.Piece = delivery.Piece;
                _deliveryService.Update(deliveryDB);
                return View("Index", _deliveryService.GetStockList());
            }
            return View("Error");
        }
        public IActionResult Delete(int Id)
        {
            var isLogin = HttpContext.Session.GetString("isUserLogin");
            if (isLogin == "true")
            {
                var delivery = _deliveryService.GetById(Id);
                _deliveryService.Delete(delivery);
                return View("Index", _deliveryService.GetStockList());
            }
            return RedirectToAction("Login", "Home");
            
        }
    }
}
