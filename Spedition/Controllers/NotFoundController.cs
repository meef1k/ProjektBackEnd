using Microsoft.AspNetCore.Mvc;

namespace Spedition.Controllers
{
    public class NotFoundController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.errorMessage = "Page not found";
                    break;
            }
            return View("NotFound");
        }
    }
}
