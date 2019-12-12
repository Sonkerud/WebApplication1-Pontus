using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2HundASP.Models
{
    public class DogsService
    {
        static int idCounter = 1;
        private static List<Dog> dogList = new List<Dog>
        {
            new Dog{Id = idCounter++, Name = "Pontus", Age = 232, ImgSrc="dog2.jpg"},
            new Dog{Id = idCounter++, Name = "Viktor", Age = 224, ImgSrc="dog1.jpg"},
            new Dog{Id = idCounter++, Name = "Alexander", Age = 196, ImgSrc="dog3.jpg"},
        };

        public void AddDog(Dog dog)
        {
            dog.Id = idCounter++;
            dogList.Add(dog);
        }
        public void DeleteDog(int id)
        {
            var dogToDelete = GetDogById(id);

            dogList.Remove(dogToDelete);
        }

        public void EditDog(Dog dog)
        {
            var dogToEdit = GetDogById(dog.Id);

            dogToEdit.Name = dog.Name;
            dogToEdit.Age = dog.Age;
        }

        public Dog[] GetAllDogs()
        {
            return dogList.ToArray();
        }

        public void SortDogs()
        {

        }

        public Dog GetDogById(int id) => dogList.Single(x => x.Id == id);
    }
}
