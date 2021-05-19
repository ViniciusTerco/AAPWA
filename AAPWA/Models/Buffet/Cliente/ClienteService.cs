using System;
using System.Collections.Generic;
using System.Linq;
using AAPWA.Data;
using AAPWA.Models.Buffet.Evento;
using Microsoft.EntityFrameworkCore;

namespace AAPWA.Models.Buffet.Cliente
{
    public class ClienteService
    {
        private readonly DataBaseContext _databaseContext;

        public ClienteService(
            DataBaseContext databaseContext
        )
        {
            _databaseContext = databaseContext;
        }
 
        public List<ClienteEntity> ObterClientes()
        {

            return _databaseContext.Clientes.Include(c => c.Eventos).ToList();

         // OBTER UM ÚNICO OBJETO
            /*
            var primeiroCliente = _databaseContext.Clientes.First();
            var primeiroClienteOuNulo = _databaseContext.Clientes.FirstOrDefault();
            var clienteEspecifico1 = _databaseContext
                .Clientes.Single(c => c.Id.ToString()
                    .Equals("08d8f887-cd09-421d-8ee1-a0f9f0d36e57") );
            var clienteEspecifico2 = _databaseContext
                .Clientes.Single(c => c.Nome.Contains("Jo") );
            var clienteEspecifico3 = _databaseContext
                .Clientes.Find("08d8f887-cd09-421d-8ee1-a0f9f0d36e57");
            
            if (clienteEspecifico != null) {
                Console.WriteLine(clienteEspecifico.Id);
                Console.Write(" :: " + clienteEspecifico.Nome);
                Console.Write(" :: " + clienteEspecifico.Email);
            }
            */
            
            // OBTER MÚLTIPLOS OBJETOS
            //var clientes = _databaseContext.Clientes.ToList();
            /*
            var clientes = _databaseContext.Clientes
                .Where(
                    c => c.Nome.StartsWith("Jo") &&
                                    c.Nome.EndsWith("e")
                ).ToList();
            */
            
            // ORDENAÇÃO
            /*
            var clientes = _databaseContext.Clientes
                .OrderBy(c => c.Nome).ToList();
            */
            /*
            foreach (var cliente in clientes) {
                Console.WriteLine("----");
                Console.WriteLine(cliente.Id);
                Console.Write(" :: " + cliente.Nome);
                Console.Write(" :: " + cliente.Email);
            }
            */
            
            // ENTIDADES RELACIONADAS
            var cliente = _databaseContext.Clientes
                .Include(c => c.Eventos)
                .ToList()
                .Single(c => c.Id.ToString()
                    .Equals("08d8f887-cd09-421d-8ee1-a0f9f0d36e57")
                );

            if (cliente != null) {
                Console.Write(" :: " + cliente.nome);
                Console.Write(" :: " + cliente.email);
                Console.Write(" :: " + cliente.Eventos.Count);
            }

            //return cliente;
            //return _databaseContext.Clientes.ToList();
        }

        public List<ClienteEntity> ObterClientesComFiltro(string filtroNome, string filtroEmail, bool apenasComEventos)
        {

            var listaClientes = _databaseContext.Clientes
                .Include(c => c.Eventos)
                .AsQueryable();
                    
                

            if (filtroNome != null)
            {
                listaClientes = listaClientes.Where(c => c.nome.Contains(filtroNome));
            }
            
            if (filtroEmail != null)
            {
                listaClientes = listaClientes.Where(c => c.email.Contains(filtroEmail));
            }
            
            if (apenasComEventos != null)
            {
                listaClientes = listaClientes.Where(c => c.Eventos.Count > 0);
            }
            
            return listaClientes.ToList();
            
        }
    }
}