using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AAPWA.ViewsModel.Cliente
{
    public class AdicionarViewModel
    {
        public string[] FormMensagensErro { get; set; }
        
        public ICollection<SelectListItem> Cliente { get; set; }
        
        public AdicionarViewModel()
        {
            Cliente = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "")
            };
        }
       
    }
}