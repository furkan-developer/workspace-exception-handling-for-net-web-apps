using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GlobalExceptionHandling.Models;
using Microsoft.AspNetCore.Diagnostics;
using GlobalExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace GlobalExceptionHandling.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        throw new ProductNotFoundException();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [AllowAnonymous]
    public IActionResult Error()
    {
        string exceptionMessage = "An unexpected error occurred.";
        var exceptionHandlerPathFeature =
          HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature is not null)
        {
            Response.StatusCode = exceptionHandlerPathFeature.Error switch
            {
                ResourceNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            exceptionMessage = Response.StatusCode != 500 ? exceptionHandlerPathFeature.Error.Message : "500 Internal Server Error";

            return View(new ErrorViewModel { ErrorMessage = exceptionMessage });
        }

        return View(new ErrorViewModel { ErrorMessage = exceptionMessage });
    }
}
