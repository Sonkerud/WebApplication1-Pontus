﻿using AjaxDemoASP.Models.ViewModels;
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
            new MovieVM {Id = 1, Title = "Titanic", Description = "A Movie About A Boat"},
            new MovieVM {Id = 2, Title = "Nalle Puh", Description = "Nalle Puh is a bear"},
            new MovieVM {Id = 3, Title = "Matrix", Description = "People in black coats"},

        };
        public MovieVM GetMovieById(int id)
        {
            return listOfMovies.FirstOrDefault(x => x.Id == id);
        }

    }
}
