using AAPWA.Models.Buffet.Convidado;
using AAPWA.ViewsModel.Convidado;
using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers
{
    public class ConvidadoController : Controller
    {
        private readonly ConvidadoService _convidadoService;

        public ConvidadoController(ConvidadoService convidadoService)
        {
            _convidadoService = convidadoService;
        }
        
        // GET
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            return View(viewModel);
        }
    }
}