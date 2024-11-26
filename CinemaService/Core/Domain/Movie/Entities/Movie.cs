namespace Domain.Movies.Entities
{
    public class Movie
    {
        public int Id { get; set; } // Identificador único
        public string Title { get; set; } // Nome do filme
        public string Description { get; set; } // Breve resumo
        public int Duration { get; set; } // Duração em minutos
        public double AverageRating { get; set; } // Avaliação média
        public bool IsShowing { get; set; } // Está em cartaz
        public bool IsActive { get; set; } // Está ativo
        public string ImageUrl { get; set; }
    }
}