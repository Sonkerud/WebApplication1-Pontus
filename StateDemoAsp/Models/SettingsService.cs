using StateDemoAsp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using StateDemoAsp.Controllers;

namespace StateDemoAsp.Models
{
    public class SettingsService 
    {
        private readonly IMemoryCache cache;
        private readonly IHttpContextAccessor accesor;
        private readonly ITempDataDictionary tempData;

        public SettingsService(IMemoryCache cache, IHttpContextAccessor accesor, ITempDataDictionaryFactory tempFactory)
        {
            this.cache = cache;
            this.accesor = accesor;
            this.tempData = tempFactory.GetTempData(accesor.HttpContext);
        }
     
       public DisplayVM GetModel()
        {
            DisplayVM model = new DisplayVM();
            model.Message = GetTempData();
            
            model.SupportEmail = cache.Get<string>("SupportEmail");
            model.CompanyName = accesor.HttpContext.Session.GetString("CompanyName");
            model.Name = accesor.HttpContext.Request.Cookies["Name"];
            return model;
        }

        public void CreateModel(CreateVM model)
        {
            SetTempData("Dina värden har inte sparats");
            cache.Set("SupportEmail", model.SupportEmail);
            accesor.HttpContext.Session.SetString("CompanyName", model.CompanyName);
            accesor.HttpContext.Response.Cookies.Append("Name", model.Name, new CookieOptions { Expires = DateTime.Now.AddSeconds(5) });
        }

        public string GetTempData()
        {
            var tempDataDictionaryFactory = accesor.HttpContext.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
            var tempDataDictionary = tempDataDictionaryFactory.GetTempData(accesor.HttpContext);
           

            if (tempDataDictionary.TryGetValue("Message", out object value))
            {
                return (string)value;
            }
            else
            {
                return "";
            }
        }

        public void SetTempData(string message)
        {

            tempData["Message"] = message;

        }
    }
}
