using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzz.Pages
{
    public class Zapisane_w_sesjiModel : PageModel
    {
        public List<Address> listOfNumbers;
        public void OnGet()
        {
            var SessionListOfNumbersJSON = HttpContext.Session.GetString("SessionListOfNumbers");
            if (SessionListOfNumbersJSON != null)
            {
                listOfNumbers = JsonConvert.DeserializeObject<List<Address>>(SessionListOfNumbersJSON);
            }
        }
    }
}
