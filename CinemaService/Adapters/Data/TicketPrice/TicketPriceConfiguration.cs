using Domain.TicketPrices.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TicketPriceConfiguration : IEntityTypeConfiguration<TicketPrice>
{
    public void Configure(EntityTypeBuilder<TicketPrice> builder)
    {
        builder.ToTable("TicketPrices");

        builder.HasKey(tp => tp.Id);

        builder.Property(tp => tp.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(tp => tp.CreatedAt)
            .IsRequired();

        builder.Property(tp => tp.UpdatedAt)
            .IsRequired();

        builder.Property(tp => tp.IsActive)
            .IsRequired();
    }
}
