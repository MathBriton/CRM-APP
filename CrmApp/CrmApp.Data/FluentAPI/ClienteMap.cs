using CrmApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrmApp.Data.FluentAPI
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Chave primária
            builder.HasKey(c => c.Id);

            // Propriedade simples
            builder.Property(c => c.CriadoEm)
                   .IsRequired();

            // Value Object: Nome
            builder.OwnsOne(c => c.Nome, nome =>
            {
                nome.Property(p => p.Texto)
                    .HasColumnName("Nome")
                    .IsRequired()
                    .HasMaxLength(150); // Exemplo de limitação
            });

            // Value Object: Email
            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(p => p.Endereco)
                     .HasColumnName("Email")
                     .IsRequired()
                     .HasMaxLength(200);
            });

            // Value Object: Cpf
            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(p => p.Numero)
                   .HasColumnName("Cpf")
                   .IsRequired()
                   .HasMaxLength(11);
            });
        }
    }
}
