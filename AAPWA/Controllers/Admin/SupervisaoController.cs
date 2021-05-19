using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers.Admin
{
    public class SupervisaoController : AdminController
    {
        
        
        
        // GET
        public IActionResult Index()
        {
            return View(NomeDaView());
        }
    }
}