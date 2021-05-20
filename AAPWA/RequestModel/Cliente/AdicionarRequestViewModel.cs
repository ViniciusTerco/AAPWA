using System;
using System.Collections.Generic;
using AAPWA.Models.Buffet.Cliente;
using AAPWA.Models.Buffet.Evento;

namespace AAPWA.RequestModel.Cliente
{
    public class AdicionarRequestViewModel: ClienteService.IDadosBasicosClienteModel
    {
        public Guid Id { get; set; }
        public string tipo { get; set; }
        public int documento { get; set; }
        public DateTime dataNascimento { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string observacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public DateTime dataModificacao { get; set; }
        public ICollection<EventoEntity> Eventos { get; set; }
        public string email { get; set; }

        public ICollection<string> ValidarEFiltrar()
        {
            var listaDeErros = new List<string>();

            return listaDeErros;
        }
        
    }
}