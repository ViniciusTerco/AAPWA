using System;
using System.Collections.Generic;
using System.Linq;
using AAPWA.Data;
using AAPWA.Models.Buffet.Evento;
using Microsoft.EntityFrameworkCore;

namespace AAPWA.Models.Buffet.Convidado
{
    public class ConvidadoService
    {
        private readonly DataBaseContext _databaseContext;

        public ConvidadoService(
            DataBaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }

        public List<ConvidadoEntity> ObterConvidado()
        {

            return _databaseContext.Convidado.Include(c => c.nome).ToList();
        }
        
        public List<ConvidadoEntity> ObterConvidadosComFiltro(string filtroNome, string filtroEmail)
        {

            var listaConvidados = _databaseContext.Convidado
                .Include(c => c.nome)
                .AsQueryable();


            if (filtroNome != null)
            {
                listaConvidados = listaConvidados.Where(c => c.nome.Contains(filtroNome));
            }

            if (filtroEmail != null)
            {
                listaConvidados = listaConvidados.Where(c => c.email.Contains(filtroEmail));
            }

            return listaConvidados.ToList();

        }
        
        
        public ConvidadoEntity ObterPorId(Guid id)
        {
            try {
                return _databaseContext.Convidado
                    .Include(c => c.id)
                    .First(c => c.id == id);
            } catch {
                throw new Exception("Convidado de ID #" + id + " não encontrado");
            }
        }

        public ConvidadoEntity Adicionar(IDadosBasicosConvidadoModel dadosBasicos)
        {
            var novoConvidado = ValidarDadosBasicos(dadosBasicos);
            _databaseContext.Convidado.Add(novoConvidado);
            _databaseContext.SaveChanges();

            return novoConvidado;
        }

        public ConvidadoEntity Editar(
            Guid id,
            IDadosBasicosConvidadoModel dadosBasicos
        )
        {
            var convidadoEntity = ObterPorId(id);
            convidadoEntity = ValidarDadosBasicos(dadosBasicos, convidadoEntity);
            _databaseContext.SaveChanges();

            return convidadoEntity;
        }

        public ConvidadoEntity Remover(Guid id)
        {
            var convidadoEntity = ObterPorId(id);
            _databaseContext.Convidado.Remove(convidadoEntity);
            _databaseContext.SaveChanges();

            return convidadoEntity;
        }
        
        
        private ConvidadoEntity ValidarDadosBasicos(
            IDadosBasicosConvidadoModel dadosBasicos,
            ConvidadoEntity entidadeExistente = null
        )
        {
            // Instanciar ou utilizar entidade previamente instanciada
            var entidade = entidadeExistente ?? new ConvidadoEntity();

            // Validar e Atribuir Descrição
            if (dadosBasicos.nome == null) {
                throw new Exception("O Nome é obrigatória");
            }

            if (dadosBasicos.documento == null) {
                throw new Exception("O documento é obrigatório");
            }
            
            if (dadosBasicos.email == null) {
                throw new Exception("O E-mail é obrigatória");
            }

            if (dadosBasicos.dataNascimento == null) {
                throw new Exception("A Data Nascimento é obrigatória");
            }
           
            if (dadosBasicos.evento == null) {
                throw new Exception("O Evento é obrigatória");
            }
            
            if (dadosBasicos.situacao == null) {
                throw new Exception("A Situação é obrigatória");
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
        
        public interface IDadosBasicosConvidadoModel
        {
            public Guid id { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public int documento { get; set; }
            public DateTime dataNascimento { get; set; }
            public EventoEntity evento { get; set; }
            public ConvidadoSituacaoEntity situacao { get; set; }
            public string observacao { get; set; }
            public DateTime dataInclusao { get; set; }
            public DateTime dataModificacao { get; set; }
        }
    }
}