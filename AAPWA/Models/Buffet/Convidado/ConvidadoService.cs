using System.Collections.Generic;
using System.Linq;
using AAPWA.Data;
using Microsoft.EntityFrameworkCore;

namespace AAPWA.Models.Buffet.Convidado
{
    public class ConvidadoService
    {
        private readonly DataBaseContext _databaseContext;

        public ConvidadoService(
            DataBaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }

        public List<ConvidadoEntity> ObterClientes()
        {

            return _databaseContext.Convidado.Include(c => c.nome).ToList();
        }
        
        public List<ConvidadoEntity> ObterConvidadosComFiltro(string filtroNome, string filtroEmail)
        {

            var listaConvidados = _databaseContext.Convidado
                .Include(c => c.nome)
                .AsQueryable();
                    
            
            if (filtroNome != null)
            {
                listaConvidados = listaConvidados.Where(c => c.nome.Contains(filtroNome));
            }
            
            if (filtroEmail != null)
            {
                listaConvidados = listaConvidados.Where(c => c.email.Contains(filtroEmail));
            }
            
            return listaConvidados.ToList();
            
        }

    }
}