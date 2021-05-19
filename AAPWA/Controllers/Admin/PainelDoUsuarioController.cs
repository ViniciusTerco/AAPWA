using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers.Admin
{
    public class PainelDoUsuarioController : AdminController
    {
        // GET
        public IActionResult Index()
        {
            return View(NomeDaView());
        }
    }
}