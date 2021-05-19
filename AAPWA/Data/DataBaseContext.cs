using System;
using AAPWA.Models.Acesso;
using AAPWA.Models.Buffet.Cliente;
using AAPWA.Models.Buffet.Convidado;
using AAPWA.Models.Buffet.Evento;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AAPWA.Data
{
    public class DataBaseContext : IdentityDbContext<Usuario,Papel,Guid>
    {
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<ClienteTipoEntity> ClienteTipo { get; set; }
        
        public DbSet<ConvidadoEntity> Convidado { get; set; } 
        public DbSet<ConvidadoSituacaoEntity> ConvidadoSituacao { get; set; }
        
        public DbSet<EventoEntity> Eventos { get; set; } 
        public DbSet<EventoTipoEntity> EventoTipo { get; set; }
        public DbSet<EventoSituacaoEntity> EventoSituacao { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
    }
}
