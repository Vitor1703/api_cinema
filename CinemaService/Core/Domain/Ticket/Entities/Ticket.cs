using Domain.Sessions.Entities;
using Domain.Users.Entities;

namespace Domain.Tickets.Entities
{
    public class Ticket
    {
        public int Id { get; set; } // Identificador único
        public int SessionId { get; set; } // Sessão associada ao ingresso
        public int UserId { get; set; } // Usuário que comprou o ingresso
        public int SeatNumber { get; set; } // Número do assento reservado
        public DateTime PurchaseDate { get; set; } // Data/hora da compra
        public decimal Price { get; set; } // Preço do ingresso

        // Relacionamentos
        public Session Session { get; set; }
        public User User { get; set; }
    }
}
