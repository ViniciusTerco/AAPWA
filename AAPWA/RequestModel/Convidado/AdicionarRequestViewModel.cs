using System;
using System.Collections.Generic;
using AAPWA.Models.Buffet.Convidado;
using AAPWA.Models.Buffet.Evento;

namespace AAPWA.RequestModel.Convidado
{
    public class AdicionarRequestViewModel : ConvidadoService.IDadosBasicosConvidadoModel
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
        
        
        public ICollection<string> ValidarEFiltrar()
        {
            var listaDeErros = new List<string>();

            return listaDeErros;
        }
    }
}