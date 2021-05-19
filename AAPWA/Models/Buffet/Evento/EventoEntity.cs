using System;
using AAPWA.Models.Buffet.Cliente;

namespace AAPWA.Models.Buffet.Evento
{
    public class EventoEntity
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

        public EventoEntity()
        {
            Id = new Guid();
        }
    }
}