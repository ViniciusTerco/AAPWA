using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers
{
    public class AjudaController : Controller
    {
        public AjudaController(){
        }

        public IActionResult Index()
        {   
            return View();
        }
    }
}