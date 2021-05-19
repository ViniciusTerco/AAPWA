using AAPWA.Models.Buffet.Cliente;
using AAPWA.ViewsModel.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        
        // GET
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            return View(viewModel);

            var listaClientes = _clienteService.ObterClientes();

            foreach (ClienteEntity clienteEntity in listaClientes)
            {
                
            }

        }
    }
}