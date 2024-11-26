using Application.Movies.Dtos;

namespace Application.Responses
{
    public class MovieResponse : Response
    {
        public MovieDto Data { get; set; }

        public MovieResponse(MovieDto data)
        {
            Data = data;
        }
    }
}
