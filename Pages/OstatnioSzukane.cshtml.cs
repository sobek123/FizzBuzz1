using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzz.Models;
using FizzBuzz.Data;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Linq.Dynamic;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzz.Pages
{
    [Authorize]
    public class OstatnioSzukaneModel : PageModel
    {
        private readonly NumberContext _context;
        public IList<Address> listOfNumbers { get; set; }

        public OstatnioSzukaneModel(NumberContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var NumberQuery = (from Address in _context.Address
                              
                               select Address).Take(20);
            listOfNumbers = NumberQuery.ToList();
            
        }
    }

}
