using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication6.Models;

namespace App.Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError(exceptionDetails.Error, "Erro Handling");
            
            var exceptionModel = new ErrorViewModel
            {
                ErrorMessage = exceptionDetails.Error.Message
            };

            return View(exceptionModel);
        }
    }
}