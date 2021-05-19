using System;
using AAPWA.Models.Buffet.Evento;

namespace AAPWA.Models.Buffet.Convidado
{
    public class ConvidadoEntity
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
        
        public ConvidadoEntity()
        {
            id = new Guid();
            
        }
    }
}