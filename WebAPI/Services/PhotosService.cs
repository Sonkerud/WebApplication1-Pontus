using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.ViewModels;

namespace WebAPI.Services
{
    public class PhotosService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public PhotosService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<PhotosIndexVM[]> GetPhotosFromExternalApi()
        {
            var httpClient = httpClientFactory.CreateClient();
            var url = $"https://jsonplaceholder.typicode.com/photos";

            var json = await httpClient.GetStringAsync(url);
            var photoArray = JsonConvert.DeserializeObject<PhotosIndexVM[]>(json);
            return photoArray.Take(10).ToArray();
        }

     
    }
}
