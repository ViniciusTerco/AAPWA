using System;

namespace AAPWA.Models.Buffet.Evento
{
    public class EventoTipoEntity
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }
        
        public EventoTipoEntity()
        {
            Id = new Guid();
            
        }
    }
}