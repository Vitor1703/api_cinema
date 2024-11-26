using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Tickets.Entities;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.SeatNumber).IsRequired();
        builder.Property(t => t.PurchaseDate).IsRequired();
        builder.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(t => t.Session)
            .WithMany()
            .HasForeignKey(t => t.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
