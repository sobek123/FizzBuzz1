using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzz.Models;
using FizzBuzz.Data;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NumberContext _context;
        private readonly ILogger<IndexModel> _logger;
        public List<Address> listOfNumbers { get; set; }

        [BindProperty]
        public Address numbers { get; set; }

        [TempData]
        public string message { get; set; }


        public IndexModel(ILogger<IndexModel> logger, NumberContext context)
        {
            _logger = logger;
            _context = context;
        }


        public void OnGet()
        {

        }

        public List<Address> checkingListOfNumbers()
        {
            var SessionNumbersList = HttpContext.Session.GetString("SessionListOfNumbers");
            if (SessionNumbersList != null)
            {
                listOfNumbers = JsonConvert.DeserializeObject<List<Address>>(SessionNumbersList);
            }
            else listOfNumbers = new List<Address>();
            return listOfNumbers;
        }

        public string messageCheck(int number)
        {
            if (number % 3 == 0)
            {
                message += "Fizz";
            }
            if (number % 5 == 0)
            {
                message += "Buzz";
            }
            if (message == null)
            {
                message += "Liczba " + number + " nie spelnia kretyriow wyszukiwania FizzBuzz.";
            }
            return message;
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                listOfNumbers = checkingListOfNumbers();
               numbers.Message = messageCheck(numbers.Number);
                numbers.Date = DateTime.Now.ToString();
               listOfNumbers.Add(numbers);
                _context.Address.Add(numbers);
                _context.SaveChanges();
                HttpContext.Session.SetString("SessionListOfNumbers", JsonConvert.SerializeObject(listOfNumbers));
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
