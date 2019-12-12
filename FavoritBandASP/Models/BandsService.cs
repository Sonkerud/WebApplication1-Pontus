using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgift1FavoritBandASP.Models
{
    public class BandsService
    {
        private List<Band> listOfBands = new List<Band>
        {
           new Band {Id = 1, Name = "Metallica", Description="Trash Metal", imgUrl="Photo2_Metallica.jpg", albums = { "Kill em all", "Ride the lightning", "Master of puppets"}},
           new Band {Id = 2, Name = "U2", Description="Rock",  imgUrl="u2.jpg" , albums = { "U21", "U22", "U23"}},
           new Band {Id = 3, Name = "Spice Girls", Description="Girl Power Music",  imgUrl="spice.jpg",albums = { "Spice och så", "Girls Spicisar", "Master of Spice"} }
        };

        public Band GetBandById(int id)
        {
            return listOfBands.First(x => x.Id == id);
        }

        public Band[] GetAllBands()
        {
            return listOfBands.ToArray();
        }

    }
}
