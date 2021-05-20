using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AAPWA.ViewsModel.Convidado
{
    public class AdicionarViewModel
    {
        public string[] FormMensagensErro { get; set; }
        
        public ICollection<SelectListItem> Convidado { get; set; }
        
        public AdicionarViewModel()
        {
            Convidado = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "")
            };
        }
    }
}