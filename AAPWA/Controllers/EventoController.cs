using System;
using System.Collections.Generic;
using AAPWA.Models.Buffet.Evento;
using AAPWA.RequestModel.Evento;
using AAPWA.ViewsModel.Evento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var viewModel = new IndexViewModel()
            {
                MensagemSucesso = (string) TempData["formMensagemSucesso"],
                MensagemErro = (string) TempData["formMensagemErro"]
            };
            

            var listaEventos = _eventoService.ObterEvento();

            foreach (EventoEntity eventoEntity in listaEventos)
            { viewModel.evento.Add(new Evento()
                {
                    id = eventoEntity.Id.ToString(),
                    tipo = eventoEntity.tipo.ToString(),
                    descricao = eventoEntity.descricao,
                    dataInicio = eventoEntity.dataInicio.ToShortDateString(),
                    dataFim = eventoEntity.dataFim.ToShortDateString(),
                    horaInicial = eventoEntity.horaInicial,
                    horaFinal = eventoEntity.horaFinal,
                    situacao = eventoEntity.situacao.ToString(),
                    descricaoLocal = eventoEntity.descricaoLocal,
                    endereco = eventoEntity.endereco,
                    observacao = eventoEntity.observacao,
                    dataInclusao = eventoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = eventoEntity.dataModificacao.ToShortDateString()
                    
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

            var eventos = _eventoService.ObterEvento();
            foreach (var eventoEntity in eventos) {
                viewModel. Eventos.Add(new SelectListItem()
                {
                    /*
                    id = eventoEntity.Id.ToString(),
                    tipo = eventoEntity.tipo.ToString(),
                    descricao = eventoEntity.descricao,
                    dataInicio = eventoEntity.dataInicio.ToShortDateString(),
                    dataFim = eventoEntity.dataFim.ToShortDateString(),
                    horaInicial = eventoEntity.horaInicial,
                    horaFinal = eventoEntity.horaFinal,
                    situacao = eventoEntity.situacao.ToString(),
                    descricaoLocal = eventoEntity.descricaoLocal,
                    endereco = eventoEntity.endereco,
                    observacao = eventoEntity.observacao,
                    dataInclusao = eventoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = eventoEntity.dataModificacao.ToShortDateString()
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
                _eventoService.Adicionar(requestModel);
                TempData["formMensagemSucesso"] = "Evento adicionado com sucesso!";

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
                var eventoEntity = _eventoService.ObterPorId(param);

                var viewModel = new EditarViewModel()
                {
                    id = eventoEntity.Id.ToString(),
                    tipo = eventoEntity.tipo.ToString(),
                    descricao = eventoEntity.descricao,
                    dataInicio = eventoEntity.dataInicio.ToShortDateString(),
                    dataFim = eventoEntity.dataFim.ToShortDateString(),
                    horaInicial = eventoEntity.horaInicial,
                    horaFinal = eventoEntity.horaFinal,
                    situacao = eventoEntity.situacao.ToString(),
                    descricaoLocal = eventoEntity.descricaoLocal,
                    endereco = eventoEntity.endereco,
                    observacao = eventoEntity.observacao,
                    dataInclusao = eventoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = eventoEntity.dataModificacao.ToShortDateString()
                };

                var evento = _eventoService.ObterEvento();
                foreach (var eventoEntity in evento) {
                    viewModel.eventoEntity.Add(new SelectListItem()
                    {
                        /*
                        id = eventoEntity.Id.ToString(),
                        tipo = eventoEntity.tipo.ToString(),
                        descricao = eventoEntity.descricao,
                        dataInicio = eventoEntity.dataInicio.ToShortDateString(),
                        dataFim = eventoEntity.dataFim.ToShortDateString(),
                        horaInicial = eventoEntity.horaInicial,
                        horaFinal = eventoEntity.horaFinal,
                        situacao = eventoEntity.situacao.ToString(),
                        descricaoLocal = eventoEntity.descricaoLocal,
                        endereco = eventoEntity.endereco,
                        observacao = eventoEntity.observacao,
                        dataInclusao = eventoEntity.dataInclusao.ToShortDateString(),
                        dataModificacao = eventoEntity.dataModificacao.ToShortDateString()
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
                _eventoService.Editar(param, requestModel);
                TempData["formMensagemSucesso"] = "Evento editado com sucesso!";

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
                var eventoEntity = _eventoService.ObterPorId(param);

                var viewModel = new RemoverViewModel()
                {
                    id = eventoEntity.Id.ToString(),
                    tipo = eventoEntity.tipo.ToString(),
                    descricao = eventoEntity.descricao,
                    dataInicio = eventoEntity.dataInicio.ToShortDateString(),
                    dataFim = eventoEntity.dataFim.ToShortDateString(),
                    horaInicial = eventoEntity.horaInicial,
                    horaFinal = eventoEntity.horaFinal,
                    situacao = eventoEntity.situacao.ToString(),
                    descricaoLocal = eventoEntity.descricaoLocal,
                    endereco = eventoEntity.endereco,
                    observacao = eventoEntity.observacao,
                    dataInclusao = eventoEntity.dataInclusao.ToShortDateString(),
                    dataModificacao = eventoEntity.dataModificacao.ToShortDateString()
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
                _eventoService.Remover(param);
                TempData["formMensagemSucesso"] = "Evento removido com sucesso!";

                return RedirectToAction("Index");
            } catch (Exception exception) {
                TempData["formMensagensErro"] = new List<string> {exception.Message};

                return RedirectToAction("Remover");
            }
        }
        
    }
}