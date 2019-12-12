using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2HundASP.Models
{
    public class DogImager
    {
        public Dog Dog { get; set; }
        public List<string> ImgSrcList = new List<string>()
        {
            "dog1.jpg","dog2.jpg","dog3.jpg",
            "dog4.jpg","dog5.jpg","dog6.jpg",
            "dog7.jpg","dog8.jpg"
        };
    }
}
