using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Rooms.Entities;

namespace Data.Rooms
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Define o nome da tabela
            builder.ToTable("Rooms");

            // Define a chave primária
            builder.HasKey(r => r.Id);

            // Configurações para a propriedade 'Name'
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100); // Limite máximo para o nome da sala

            // Configurações para a propriedade 'Capacity'
            builder.Property(r => r.Capacity)
                .IsRequired(); // Capacidade é obrigatória

            // Configurações para a propriedade 'IsActive'
            builder.Property(r => r.IsActive)
                .IsRequired(); // O status ativo/inativo é obrigatório
        }
    }
}
