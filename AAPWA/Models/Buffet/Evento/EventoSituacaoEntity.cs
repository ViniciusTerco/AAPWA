using System;

namespace AAPWA.Models.Buffet.Evento
{
    public class EventoSituacaoEntity
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }
        
        public EventoSituacaoEntity()
        {
            Id = new Guid();
        }
    }
}