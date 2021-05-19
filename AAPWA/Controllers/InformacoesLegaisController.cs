using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers
{
    public class InformacoesLegaisController : Controller
    {
        public InformacoesLegaisController(){
        }

        public IActionResult TermosDeUso()
        {   
            return View();
        }
        
        public IActionResult PoliticaDePrivacidade()
        {   
            return View();
        }
    }
}