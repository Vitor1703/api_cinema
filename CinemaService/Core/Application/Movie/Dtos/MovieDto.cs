using Domain.Movies.Entities;

namespace Application.Movies.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double AverageRating { get; set; }
        public bool IsShowing { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; } // Novo campo

        public MovieDto(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            Duration = movie.Duration;
            AverageRating = movie.AverageRating;
            IsShowing = movie.IsShowing;
            IsActive = movie.IsActive;
            ImageUrl = movie.ImageUrl;
        }
    }
}
