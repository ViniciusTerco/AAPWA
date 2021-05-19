using System;

namespace AAPWA.Models.Buffet.Cliente
{
    public class ClienteTipoEntity
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }
        
        public ClienteTipoEntity()
        {
            Id = new Guid();
            
        }
    }
}