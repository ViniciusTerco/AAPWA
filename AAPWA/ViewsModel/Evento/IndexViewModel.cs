using System.Collections.Generic;

namespace AAPWA.ViewsModel.Evento
{
    public class IndexViewModel
    {
         public ICollection<Evento> evento { get; set; }
         public string MensagemSucesso { get; set; }
         public string MensagemErro { get; set; }
         
         public IndexViewModel()
         {
             evento = new List<Evento>();
         }

    
    }
    
        public class Evento
        {
            public string id { get; set; }
            public string tipo { get; set; }
            public string descricao { get; set; }
            public string dataInicio { get; set; }
            public string dataFim { get; set; }
            public string horaInicial { get; set; }
            public string horaFinal { get; set; }
            public string situacao { get; set; }
            public string descricaoLocal { get; set; }
            public string endereco { get; set; }
            public string observacao { get; set; }
            public string dataInclusao { get; set; }
            public string dataModificacao { get; set; }
        }
    
}