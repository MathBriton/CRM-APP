using CrmApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApp.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }    
        public Cpf Cpf { get; private set; }
        public DateTime CriadoEm { get; private set; }

        private Cliente () { }

        public Cliente (Nome nome, Email email, Cpf cpf)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Cpf = cpf;
            CriadoEm = DateTime.UtcNow;
        }

        public void AtualizarNome(Nome novoNome)
        {
            Nome = novoNome;
        }
    }
}
