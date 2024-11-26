namespace Application.Sessions.Requests
{
    public class CreateSessionRequest
    {
        public int MovieId { get; set; } // ID do filme relacionado
        public int RoomId { get; set; } // ID da sala onde será exibida
        public DateTime StartTime { get; set; } // Data e hora de início da sessão
        public int Duration { get; set; } // Duração do filme em minutos
        public decimal Price { get; set; } // Preço do ingresso
    }

    public class UpdateSessionRequest
    {
        public DateTime StartTime { get; set; } // Nova data e hora de início
        public int Duration { get; set; } // Nova duração do filme em minutos
        public decimal Price { get; set; } // Novo preço do ingresso
    }
}
