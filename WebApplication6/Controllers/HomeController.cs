using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using App.Core;
using App.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication6.Models;
using AutoMapper;
using App.Core.Dto;
using App.Web.Models;
using App.Core.Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private IParamGenService _service;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IParamGenService service)
        {
            _service = service;
            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {
            _logger.LogWarning("test");

            var list =await _service.GetAllParamGen();

            return View();
        }

        [Route("HataOlustur")]
        public async Task<IActionResult> ThrowException()
        {
            throw new Exception("hata oluştu");
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
