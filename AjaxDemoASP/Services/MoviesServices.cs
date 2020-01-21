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

        public MovieVM GetMovieVM()
        {
            var movieVM = new MovieVM
            {
                Movies = listOfMovies,
                Actors = new List<Actors>
                {
                    new Actors { Name = "Rune Andersson", Age = 21},
                    new Actors { Name = "Bella Bandersson", Age = 31}
                },
                Title = "Det gröna vågen"
            };
            return movieVM;
        }
    }
}
