using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieREST_API_Lab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieDAL md = new MovieDAL();

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return md.GetAllMovies();
        }

        [HttpGet("genre={value}")]
        public List<Movie> GetMoviesByGenre(string value)
        {
            return md.GetMoviesByGenre(value);
        }

        [HttpGet("random")]
        public Movie GetRandomMovie()
        {
            return md.GetRandomMovie();
        }

        [HttpGet("genre={value}/random")]
        public Movie GetRandomByGenre(string value)
        {
            return md.GetRandomByGenre(value);
        }

        [HttpGet("Moviesbynumber/number={value}")]
        public List<Movie> MoviesByNumber(int value)
        {
            return md.GetMoviesByAmount(value);
        }

    }
}
