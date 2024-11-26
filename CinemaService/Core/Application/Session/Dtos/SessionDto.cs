namespace Application.Sessions.Dtos
{
    public class SessionDto
    {
        public int Id { get; set; } // Identificador único da sessão
        public int MovieId { get; set; } // Identificador do filme
        public string MovieTitle { get; set; } // Título do filme (opcional, para exibição)
        public int RoomId { get; set; } // Identificador da sala
        public string RoomName { get; set; } // Nome da sala (opcional, para exibição)
        public DateTime StartTime { get; set; } // Data e hora de início da sessão
        public DateTime EndTime { get; set; } // Data e hora de término da sessão
        public decimal Price { get; set; } // Preço do ingresso
        public bool IsActive { get; set; } // Indica se a sessão está ativa

        // Construtor para facilitar a criação do DTO a partir de uma entidade
        public SessionDto(Domain.Sessions.Entities.Session session)
        {
            Id = session.Id;
            MovieId = session.MovieId;
            MovieTitle = session.Movie?.Title; // Inclui o título do filme se disponível
            RoomId = session.RoomId;
            RoomName = session.Room?.Name; // Inclui o nome da sala se disponível
            StartTime = session.StartTime;
            EndTime = session.EndTime;
            Price = session.Price;
            IsActive = session.IsActive;
        }
    }
}
