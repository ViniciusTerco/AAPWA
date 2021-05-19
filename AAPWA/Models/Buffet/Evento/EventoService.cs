using System.Collections.Generic;
using System.Linq;
using AAPWA.Data;
using Microsoft.EntityFrameworkCore;

namespace AAPWA.Models.Buffet.Evento
{
    public class EventoService
    {
        private readonly DataBaseContext _databaseContext;

        public EventoService(
            DataBaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }
        
        public List<EventoEntity> ObterClientes()
        {

            return _databaseContext.Eventos.Include(c => c.descricao).ToList();
        }

        public List<EventoEntity> ObterEventosComFiltro(string filtroNome)
        {

            var listaEventos = _databaseContext.Eventos
                .Include(c => c.descricao)
                .AsQueryable();
                    
            
            if (filtroNome != null)
            {
                listaEventos = listaEventos.Where(c => c.descricao.Contains(filtroNome));
            }
            
            return listaEventos.ToList();
            
        }
    }
}