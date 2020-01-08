using AjaxDemoASP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxDemoASP.Models
{
    public class MoviesServices
    {
        List<MovieVM> listOfMovies = new List<MovieVM>
        {
            new MovieVM {Title = "Titanic", Description = "A Movie About A Boat"},
            new MovieVM {Title = "Nalle Puh", Description = "Nalle Puh is a bear"},
            new MovieVM {Title = "Matrix", Description = "People in black coats"},

        };
        public MovieVM GetMovieById(int id)
        {
            return listOfMovies.FirstOrDefault(x => x.Id == id);
        }

    }
}
