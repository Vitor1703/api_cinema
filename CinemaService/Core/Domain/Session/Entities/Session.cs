using Domain.Movies.Entities;
using Domain.Rooms.Entities;

namespace Domain.Sessions.Entities
{
    public class Session
    {
        public int Id { get; set; } // Identificador único
        public int MovieId { get; set; } // Filme exibido
        public int RoomId { get; set; } // Sala onde a sessão será exibida
        public DateTime StartTime { get; set; } // Data e hora de início da sessão
        public DateTime EndTime { get; set; } // Data e hora de término da sessão
        public decimal Price { get; set; } // Preço do ingresso
        public bool IsActive { get; set; } // Indica se a sessão está ativa

        // Relacionamentos
        public Movie Movie { get; set; }
        public Room Room { get; set; }
    }
}
