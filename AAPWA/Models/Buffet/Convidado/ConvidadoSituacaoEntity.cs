using System;

namespace AAPWA.Models.Buffet.Convidado
{
    public class ConvidadoSituacaoEntity
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }
        
        public ConvidadoSituacaoEntity()
        {
            Id = new Guid();
        }
    }
}