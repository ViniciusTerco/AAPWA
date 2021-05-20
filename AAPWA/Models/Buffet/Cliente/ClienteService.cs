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
        
          
        public ClienteEntity ObterPorId(Guid id)
        {
            try {
                return _databaseContext.Clientes
                    .Include(c => c.Id)
                    .First(c => c.Id == id);
            } catch {
                throw new Exception("Cliente de ID #" + id + " não encontrado");
            }
        }

        public ClienteEntity Adicionar(IDadosBasicosClienteModel dadosBasicos)
        {
            var novoCliente = ValidarDadosBasicos(dadosBasicos);
            _databaseContext.Clientes.Add(novoCliente);
            _databaseContext.SaveChanges();

            return novoCliente;
        }

        public ClienteEntity Editar(
            Guid id,
            IDadosBasicosClienteModel dadosBasicos
        )
        {
            var clienteEntity = ObterPorId(id);
            clienteEntity = ValidarDadosBasicos(dadosBasicos, clienteEntity);
            _databaseContext.SaveChanges();

            return clienteEntity;
        }

        public ClienteEntity Remover(Guid id)
        {
            var clienteEntity = ObterPorId(id);
            _databaseContext.Clientes.Remove(clienteEntity);
            _databaseContext.SaveChanges();

            return clienteEntity;
        }
        
        private ClienteEntity ValidarDadosBasicos(
            IDadosBasicosClienteModel dadosBasicos,
            ClienteEntity entidadeExistente = null
        )
        {
            // Instanciar ou utilizar entidade previamente instanciada
            var entidade = entidadeExistente ?? new ClienteEntity();

            // Validar e Atribuir Descrição
            if (dadosBasicos.tipo == null) {
                throw new Exception("O Tipo é obrigatório");
            }

            if (dadosBasicos.documento == null) {
                throw new Exception("O documento é obrigatório");
            }
            
            if (dadosBasicos.dataNascimento == null) {
                throw new Exception("A Data Nascimento é obrigatória");
            }

            if (dadosBasicos.nome == null) {
                throw new Exception("O Nome é obrigatório");
            }
           
            if (dadosBasicos.endereco == null) {
                throw new Exception("O Endereço é obrigatório");
            }
            
            if (dadosBasicos.observacao == null) {
                throw new Exception("A Observação é obrigatória");
            }
            
            if (dadosBasicos.dataInclusao == null) {
                throw new Exception("A Data é obrigatória");
            }
            
            if (dadosBasicos.dataModificacao == null) {
                throw new Exception("A Data é obrigatória");
            }
            
            if (dadosBasicos.Eventos == null) {
                throw new Exception("O Evento é obrigatório");
            }
            
            if (dadosBasicos.email == null) {
                throw new Exception("O E-mail é obrigatório");
            }
            
            return entidade;
        }
        
        public interface IDadosBasicosClienteModel
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

        }
        
    }
}