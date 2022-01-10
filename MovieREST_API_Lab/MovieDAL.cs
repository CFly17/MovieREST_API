using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieREST_API_Lab
{
    public class MovieDAL
    {
        public List<Movie> GetAllMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return movies;
            }
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from movies where genre = '{genre}'";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();

                if (movies.Count >= 1)
                {
                    return movies;
                }
                else
                {
                    List<Movie> error = new List<Movie>();
                    error.Add(new Movie());
                    error[0].Title = $"No movie found of the genre '{genre}.'";
                    return error;
                }
            }
        }

        public Movie GetRandomMovie()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();

                //This creates a random number based on the count of our movie list.
                //This random number then becomes the index by which we get a random movie.
                Random rnd = new Random();
                int randomNum = rnd.Next(0, movies.Count);
                connect.Close();

                return movies[randomNum];
            }
        }

        public Movie GetRandomByGenre(string genre)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from movies where genre = '{genre}'";
                try
                {
                    connect.Open();
                    List<Movie> movies = connect.Query<Movie>(sql).ToList();
                    Random rnd = new Random();
                    int randomNum = rnd.Next(0, movies.Count);
                    connect.Close();
                    return movies[randomNum];
                }
                catch (InvalidOperationException)
                {
                    Movie error = new Movie();
                    error.Title = $"No movie found of the genre '{genre}.'";
                    return error;
                }
            }
        }

        public List<Movie> GetMoviesByAmount(int num)
        {
            List<Movie> movies = GetAllMovies();
            List<Movie> randomMovies = new List<Movie>();

            for (int i = 0; i < num; i++)
            {
                Random rnd = new Random();
                int randomNum = rnd.Next(0, movies.Count);
                randomMovies.Add(movies[randomNum]);
            }

            return randomMovies;
        }
    }

}
