namespace Application.Movies.Requests
{
    public class CreateMovieRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsShowing { get; set; }
        public string ImageUrl { get; set; } // Novo campo
    }
    
    public class UpdateMovieRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsShowing { get; set; }
        public string ImageUrl { get; set; } // Novo campo
    }
}
