using AjaxDemoASP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxDemoASP.Models
{
    public class MoviesServices
    {
        List<Movie> listOfMovies = new List<Movie>
        {
            new Movie {Id = 1, Title = "Titanic", Description = "A Movie About A Boat"},
            new Movie {Id = 2, Title = "Nalle Puh", Description = "Nalle Puh is a bear"},
            new Movie {Id = 3, Title = "Matrix", Description = "People in black coats"},

        };
        public MovieVM GetMovieById(int id)
        {
            return listOfMovies.Where(x => x.Id == id).Select(x => new MovieVM { 
            Description = x.Description,
            Title = x.Title,
            Id = x.Id
            }).SingleOrDefault();
        }

        public List<Movie> GetAllMovies()
        {
            return listOfMovies;
        }
    }
}
