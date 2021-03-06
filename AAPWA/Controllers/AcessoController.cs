using System.Collections.Generic;
using System.Threading.Tasks;
using AAPWA.Models.Acesso;
using AAPWA.Models.Buffet.Cliente;
using AAPWA.RequestModel;
using AAPWA.ViewsModel.Acesso;
using Microsoft.AspNetCore.Mvc;

namespace AAPWA.Controllers
{
    public class AcessoController : Controller
    {
        private readonly AcessoService _acessoService;

        public AcessoController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewmodel = new LoginViewModel();
            viewmodel.Mensagem = (string)TempData["msg-login"];
            viewmodel.ErrosLogin = (string[])TempData["erros-login"];
            return View(viewmodel);
        }
        
        [HttpPost]
        public async Task<RedirectToActionResult> Login(AcessoLoginRequestModel request)
        {
            
            var email = request.Email;
            var senha = request.Senha;

            if (email == null)
            {
                TempData["msg-cadastro"] = "Favor Informe o Email";
                return RedirectToAction("Login");
            }
            
            try
            {
                await _acessoService.AutenticaUsuario(email,senha);
                TempData["msg-login"] = "Login com Sucesso";
                TempData["logado"] = email;
                return RedirectToAction("Login");
            }
            catch (CadastrarUsuarioExecption exception)
            {
                var listaErros = new List<string>();
                foreach (var identityError in exception.Erros)
                {
                    listaErros.Add(identityError.Description);
                }

                TempData["erros-login"] = listaErros;
                return RedirectToAction("Login");

            }
        }

        public IActionResult RecuperarConta()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var viewmodel = new CadastrarViewModel();
            viewmodel.Mensagem = (string)TempData["msg-cadastro"];
            viewmodel.ErrosCadastro = (string[])TempData["erros-cadastro"];
            return View(viewmodel);
        }


        [HttpPost]
        public async Task<RedirectToActionResult> Cadastrar(AcessoCadastrarRequestModel request)
        {
            var email = request.Email;
            var senha = request.Senha;
            var senhaConfirmacaoString = request.SenhaConfirmacao;

            if (email == null)
            {
                TempData["msg-cadastro"] = "Favor Informe o Email";
                return RedirectToAction("Cadastrar");
            }

            try
            {
                await _acessoService.RegistrarUsuario(email,senha);
                TempData["msg-cadastro"] = "Cadastro Realizado com Sucesso";
                return RedirectToAction("Login");
            }
            catch (CadastrarUsuarioExecption exception)
            {
                var listaErros = new List<string>();
                foreach (var identityError in exception.Erros)
                {
                    listaErros.Add(identityError.Description);
                }

                TempData["erros-cadastro"] = listaErros;
                return RedirectToAction("Cadastrar");

            }
        }
    }
}