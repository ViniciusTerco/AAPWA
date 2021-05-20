using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AAPWA.ViewsModel.Evento
{
    public class AdicionarViewModel
    {
        public string[] FormMensagensErro { get; set; }
        
        public ICollection<SelectListItem> Eventos { get; set; }
        
        public AdicionarViewModel()
        {
            Eventos = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "")
            };
        }
    }
}