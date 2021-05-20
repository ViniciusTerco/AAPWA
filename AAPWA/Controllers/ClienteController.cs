using System;
using System.Collections.Generic;
using AAPWA.Models.Buffet.Cliente;
using AAPWA.RequestModel.Cliente;
using AAPWA.ViewsModel.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var viewModel = new IndexViewModel()
            {
                MensagemSucesso = (string) TempData["formMensagemSucesso"],
                MensagemErro = (string) TempData["formMensagemErro"]
            };
            

            var listaClientes = _clienteService.ObterClientes();

            foreach (ClienteEntity clienteEntity in listaClientes)
            { viewModel.cliente.Add(new Cliente()
                {
                   id = clienteEntity.Id.ToString(),
                   tipo = clienteEntity.tipo.ToString(),
                   dataNascimento = clienteEntity.dataNascimento.ToShortDateString(),
                   nome = clienteEntity.nome,
                   endereco = clienteEntity.endereco,
                   observacao = clienteEntity.observacao,
                   dataInclusao = clienteEntity.dataInclusao.ToShortDateString(),
                   dataModificacao = clienteEntity.dataModificacao.ToShortDateString(),
                   Evento = clienteEntity.Eventos.ToString(),
                   email = clienteEntity.email.ToString()
                   
                });
            }
            return View(viewModel);
        }
        
        
        [HttpGet]
        public IActionResult Adicionar()
        {
            var viewModel = new AdicionarViewModel()
            {
                FormMensagensErro = (string[]) TempData["formMensagensErro"]
            };

            var cliente = _clienteService.ObterClientes();
            foreach (var clienteEntity in cliente) {
                viewModel.Cliente.Add(new SelectListItem()
                {
                    /*
                    id = clienteEntity.Id.ToString(),
                   tipo = clienteEntity.tipo.ToString(),
                   dataNascimento = clienteEntity.dataNascimento.ToShortDateString(),
                   nome = clienteEntity.nome,
                   endereco = clienteEntity.endereco,
                   observacao = clienteEntity.observacao,
                   dataInclusao = clienteEntity.dataInclusao.ToShortDateString(),
                   dataModificacao = clienteEntity.dataModificacao.ToShortDateString(),
                   Evento = clienteEntity.Eventos.ToString(),
                   email = clienteEntity.email.ToString()
                    */
                });
            }

            return View(viewModel);
        }

        [HttpPost]
        public RedirectToActionResult Adicionar(AdicionarRequestViewModel requestModel)
        {
            /* VALIDAÇÔES E FILTROS */
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0) {
                TempData["formMensagensErro"] = listaDeErros;

                return RedirectToAction("Adicionar");
            }

            /* OPERAÇÔES */
            try {
                _clienteService.Adicionar(requestModel);
                TempData["formMensagemSucesso"] = "Cliente adicionado com sucesso!";

                return RedirectToAction("Index");
            } catch (Exception exception) {
                TempData["formMensagensErro"] = new List<string> {exception.Message};

                return RedirectToAction("Adicionar");
            }
        }

        [HttpGet]
        public IActionResult Editar(Guid param)
        {
            /* BUSCAR ENTIDADES */
            try {
                var clienteEntity = _clienteService.ObterPorId(param);

                var viewModel = new EditarViewModel()
                {
                    id = clienteEntity.Id.ToString(),
                    tipo = clienteEntity.tipo.ToString(),
                    dataNascimento = clienteEntity.dataNascimento.ToShortDateString(),
                    nome = clienteEntity.nome,
                    endereco = clienteEntity.endereco,
                    observacao = clienteEntity.observacao,
                    dataInclusao = clienteEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = clienteEntity.dataModificacao.ToShortDateString(),
                    Evento = clienteEntity.Eventos.ToString(),
                    email = clienteEntity.email.ToString()
                };

                var cliente = _clienteService.ObterClientes();
                foreach (var clienteEntity in cliente) {
                    viewModel.clienteEntity.Add(new SelectListItem()
                    {
                        /*
                        id = clienteEntity.Id.ToString(),
                       tipo = clienteEntity.tipo.ToString(),
                       dataNascimento = clienteEntity.dataNascimento.ToShortDateString(),
                       nome = clienteEntity.nome,
                       endereco = clienteEntity.endereco,
                       observacao = clienteEntity.observacao,
                       dataInclusao = clienteEntity.dataInclusao.ToShortDateString(),
                       dataModificacao = clienteEntity.dataModificacao.ToShortDateString(),
                       Evento = clienteEntity.Eventos.ToString(),
                       email = clienteEntity.email.ToString()
                        */
                    });
                }

                return View(viewModel);
            } catch (Exception e) {
                TempData["formMensagemErro"] = e.Message;

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public RedirectToActionResult Editar(Guid param, AdicionarRequestViewModel requestModel)
        {
            /* VALIDAR FILTROS */
            var listaDeErros = requestModel.ValidarEFiltrar();
            if (listaDeErros.Count > 0) {
                TempData["formMensagensErro"] = listaDeErros;

                return RedirectToAction("Editar");
            }

            /* OPERAÇÔES */
            try {
                _clienteService.Editar(param, requestModel);
                TempData["formMensagemSucesso"] = "Cliente editado com sucesso!";

                return RedirectToAction("Index");
            } catch (Exception exception) {
                TempData["formMensagensErro"] = new List<string> {exception.Message};

                return RedirectToAction("Editar");
            }
        }

        [HttpGet]
        public IActionResult Remover(Guid param)
        {
            // BUSCANDO ENTIDADE
            try {
                var clienteEntity = _clienteService.ObterPorId(param);

                var viewModel = new RemoverViewModel()
                {
                    id = clienteEntity.Id.ToString(),
                    tipo = clienteEntity.tipo.ToString(),
                    dataNascimento = clienteEntity.dataNascimento.ToShortDateString(),
                    nome = clienteEntity.nome,
                    endereco = clienteEntity.endereco,
                    observacao = clienteEntity.observacao,
                    dataInclusao = clienteEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = clienteEntity.dataModificacao.ToShortDateString(),
                    Evento = clienteEntity.Eventos.ToString(),
                    email = clienteEntity.email.ToString()
                };

                return View(viewModel);
            } catch (Exception e) {
                TempData["formMensagemErro"] = e.Message;

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public RedirectToActionResult Remover(Guid param, object requestModel)
        {
            /* EXCLUINDO */
            try {
                _clienteService.Remover(param);
                TempData["formMensagemSucesso"] = "Cliente removido com sucesso!";

                return RedirectToAction("Index");
            } catch (Exception exception) {
                TempData["formMensagensErro"] = new List<string> {exception.Message};

                return RedirectToAction("Remover");
            }
        }
    }
}