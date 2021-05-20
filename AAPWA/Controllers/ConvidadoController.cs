using System;
using System.Collections.Generic;
using AAPWA.Models.Buffet.Convidado;
using AAPWA.RequestModel.Convidado;
using AAPWA.ViewsModel.Convidado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var viewModel = new IndexViewModel()
            {
                MensagemSucesso = (string) TempData["formMensagemSucesso"],
                MensagemErro = (string) TempData["formMensagemErro"]
            };
           

            var listaConvidado = _convidadoService.ObterConvidado();

            foreach (ConvidadoEntity convidadoEntity in listaConvidado)
            { viewModel.convidado.Add(new Convidado()
                {
                    id = convidadoEntity.id.ToString(),
                    nome = convidadoEntity.nome,
                    email = convidadoEntity.email,
                    documento = convidadoEntity.documento.ToString(),
                    dataNacimento = convidadoEntity.dataNascimento.ToShortDateString(),
                    evento = convidadoEntity.evento.ToString(),
                    situacao = convidadoEntity.situacao.ToString(),
                    observacao = convidadoEntity.observacao,
                    dataInclusao = convidadoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = convidadoEntity.dataModificacao.ToShortDateString()
                    
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

            var convidado = _convidadoService.ObterConvidado();
            foreach (var convidadoEntity in convidado) {
                viewModel.Convidado.Add(new SelectListItem()
                {
                    /*
                     id = convidadoEntity.id.ToString(),
                    nome = convidadoEntity.nome,
                    email = convidadoEntity.email,
                    documento = convidadoEntity.documento.ToString(),
                    dataNacimento = convidadoEntity.dataNascimento.ToShortDateString(),
                    evento = convidadoEntity.evento.ToString(),
                    situacao = convidadoEntity.situacao.ToString(),
                    observacao = convidadoEntity.observacao,
                    dataInclusao = convidadoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = convidadoEntity.dataModificacao.ToShortDateString()
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
                _convidadoService.Adicionar(requestModel);
                TempData["formMensagemSucesso"] = "Convidado adicionado com sucesso!";

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
                var convidadoEntity = _convidadoService.ObterPorId(param);

                var viewModel = new EditarViewModel()
                {
                    id = convidadoEntity.id.ToString(),
                    nome = convidadoEntity.nome,
                    email = convidadoEntity.email,
                    documento = convidadoEntity.documento.ToString(),
                    dataNacimento = convidadoEntity.dataNascimento.ToShortDateString(),
                    evento = convidadoEntity.evento.ToString(),
                    situacao = convidadoEntity.situacao.ToString(),
                    observacao = convidadoEntity.observacao,
                    dataInclusao = convidadoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = convidadoEntity.dataModificacao.ToShortDateString()
                };

                var convidado = _convidadoService.ObterConvidado();
                foreach (var convidadoEntity in convidado) {
                    viewModel.convidadoEntity.Add(new SelectListItem()
                    {
                        /*
                         id = convidadoEntity.id.ToString(),
                        nome = convidadoEntity.nome,
                        email = convidadoEntity.email,
                        documento = convidadoEntity.documento.ToString(),
                        dataNacimento = convidadoEntity.dataNascimento.ToShortDateString(),
                        evento = convidadoEntity.evento.ToString(),
                        situacao = convidadoEntity.situacao.ToString(),
                        observacao = convidadoEntity.observacao,
                        dataInclusao = convidadoEntity.dataInclusao.ToShortDateString(),
                        dataModificacao = convidadoEntity.dataModificacao.ToShortDateString()
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
                _convidadoService.Editar(param, requestModel);
                TempData["formMensagemSucesso"] = "Convidado editado com sucesso!";

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
                var convidadoEntity = _convidadoService.ObterPorId(param);

                var viewModel = new RemoverViewModel()
                {
                    id = convidadoEntity.id.ToString(),
                    nome = convidadoEntity.nome,
                    email = convidadoEntity.email,
                    documento = convidadoEntity.documento.ToString(),
                    dataNacimento = convidadoEntity.dataNascimento.ToShortDateString(),
                    evento = convidadoEntity.evento.ToString(),
                    situacao = convidadoEntity.situacao.ToString(),
                    observacao = convidadoEntity.observacao,
                    dataInclusao = convidadoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = convidadoEntity.dataModificacao.ToShortDateString()
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
                _convidadoService.Remover(param);
                TempData["formMensagemSucesso"] = "Convidado removido com sucesso!";

                return RedirectToAction("Index");
            } catch (Exception exception) {
                TempData["formMensagensErro"] = new List<string> {exception.Message};

                return RedirectToAction("Remover");
            }
        }
    }
}