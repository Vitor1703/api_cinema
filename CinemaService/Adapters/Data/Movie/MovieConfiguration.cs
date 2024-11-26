using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Movies.Entities;

namespace Data.Movies
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Define o nome da tabela
            builder.ToTable("Movies");

            // Define a chave primária
            builder.HasKey(m => m.Id);

            // Configurações para a propriedade 'Title'
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(200); // Limite máximo para o título do filme

            // Configurações para a propriedade 'Description'
            builder.Property(m => m.Description)
                .IsRequired(false)
                .HasMaxLength(1000); // Limite máximo para a descrição do filme

            // Configurações para a propriedade 'Duration'
            builder.Property(m => m.Duration)
                .IsRequired();

            // Configurações para a propriedade 'AverageRating'
            builder.Property(m => m.AverageRating)
                .HasDefaultValue(0) // Valor padrão inicial para avaliações
                .IsRequired();

            // Configurações para a propriedade 'IsShowing'
            builder.Property(m => m.IsShowing)
                .IsRequired();

            // Configurações para a propriedade 'IsActive'
            builder.Property(m => m.IsActive)
                .IsRequired();

            builder.Property(m => m.ImageUrl)
                .IsRequired(false);
        }
    }
}
