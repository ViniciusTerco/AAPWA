using AAPWA.Models.Buffet.Evento;
using AAPWA.ViewsModel.Evento;
using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers
{
    public class EventoController : Controller
    {
        private readonly EventoService _eventoService;

        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }
        // GET
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            return View(viewModel);
        }
    }
}