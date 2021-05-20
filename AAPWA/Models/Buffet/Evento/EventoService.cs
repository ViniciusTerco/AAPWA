using System;
using System.Collections.Generic;
using System.Linq;
using AAPWA.Data;
using Microsoft.EntityFrameworkCore;

namespace AAPWA.Models.Buffet.Evento
{
    public class EventoService
    {
        private readonly DataBaseContext _databaseContext;

        public EventoService(
            DataBaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }
        
        public List<EventoEntity> ObterEvento()
        {

            return _databaseContext.Eventos.Include(c => c.descricao).ToList();
        }

        public List<EventoEntity> ObterEventosComFiltro(string filtroNome)
        {

            var listaEventos = _databaseContext.Eventos
                .Include(c => c.descricao)
                .AsQueryable();
                    
            
            if (filtroNome != null)
            {
                listaEventos = listaEventos.Where(c => c.descricao.Contains(filtroNome));
            }
            
            return listaEventos.ToList();
            
        }
        
        public EventoEntity ObterPorId(Guid id)
        {
            try {
                return _databaseContext.Eventos
                    .Include(e => e.Id)
                    .First(e => e.Id == id);
            } catch {
                throw new Exception("Evento de ID #" + id + " não encontrado");
            }
        }

        public EventoEntity Adicionar(IDadosBasicosEventoModel dadosBasicos)
        {
            var novoEvento = ValidarDadosBasicos(dadosBasicos);
            _databaseContext.Eventos.Add(novoEvento);
            _databaseContext.SaveChanges();

            return novoEvento;
        }

        public EventoEntity Editar(
            Guid id,
            IDadosBasicosEventoModel dadosBasicos
        )
        {
            var eventoEntity = ObterPorId(id);
            eventoEntity = ValidarDadosBasicos(dadosBasicos, eventoEntity);
            _databaseContext.SaveChanges();

            return eventoEntity;
        }

        public EventoEntity Remover(Guid id)
        {
            var eventoEntity = ObterPorId(id);
            _databaseContext.Eventos.Remove(eventoEntity);
            _databaseContext.SaveChanges();

            return eventoEntity;
        }
        
        private EventoEntity ValidarDadosBasicos(
            IDadosBasicosEventoModel dadosBasicos,
            EventoEntity entidadeExistente = null
        )
        {
            // Instanciar ou utilizar entidade previamente instanciada
            var entidade = entidadeExistente ?? new EventoEntity();

            // Validar e Atribuir Descrição
            if (dadosBasicos.tipo == null) {
                throw new Exception("O Tipo é obrigatória");
            }

            if (dadosBasicos.descricao.Length < 3) {
                throw new Exception("A Descrição informada deve conter pelo menos 3 caracteres");
            }

            entidade.descricao = dadosBasicos.descricao;

            
            if (dadosBasicos.dataInicio == null) {
                throw new Exception("A Data é obrigatória");
            }

            if (dadosBasicos.dataFim == null) {
                throw new Exception("A Data é obrigatória");
            }
           
            if (dadosBasicos.horaFinal == null) {
                throw new Exception("A Hora é obrigatória");
            }
            
            if (dadosBasicos.horaFinal == null) {
                throw new Exception("A Hora é obrigatória");
            }
            
            if (dadosBasicos.situacao == null) {
                throw new Exception("A Situação é obrigatória");
            }
            
            if (dadosBasicos.descricaoLocal == null) {
                throw new Exception("A Descrição é obrigatória");
            }
            
            if (dadosBasicos.endereco == null) {
                throw new Exception("O Endereço é obrigatória");
            }
            
            if (dadosBasicos.observacao == null) {
                throw new Exception("A Observação é obrigatória");
            }
            
            if (dadosBasicos.dataInclusao == null) {
                throw new Exception("A Data é obrigatória");
            }
            
            if (dadosBasicos.dataModificacao == null) {
                throw new Exception("A Data é obrigatória");
            }
            
            return entidade;
        }
        
        public interface IDadosBasicosEventoModel
        {
            public Guid Id { get; set; }
            public EventoTipoEntity tipo { get; set; }
            public string descricao { get; set; }
            public DateTime dataInicio { get; set; }
            public DateTime dataFim { get; set; }
            public string horaInicial { get; set; }
            public string horaFinal { get; set; }
            public EventoSituacaoEntity situacao { get; set; }
            public string descricaoLocal { get; set; }
            public string endereco { get; set; }
            public string observacao { get; set; }
            public DateTime dataInclusao { get; set; }
            public DateTime dataModificacao { get; set; }
        }
    }
}