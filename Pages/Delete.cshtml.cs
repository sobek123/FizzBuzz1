using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzz.Pages
{
    public class DeleteModel : PageModel
    {
        public class Delete : PageModel
        {
            private readonly FizzBuzz.Data.NumberContext _context;

            public Delete(FizzBuzz.Data.NumberContext context)
            {
                _context = context;
            }
            
            [BindProperty]
            public Address Address { get; set; }

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Address = await _context.Address.FirstOrDefaultAsync(m => m.Id == id);

                if (Address == null)
                {
                    return NotFound();
                }
                return Page();
            }

            public async Task<IActionResult> OnPostAsync(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Address = await _context.Address.FindAsync(id);

                if (Address != null)
                {
                    _context.Address.Remove(Address);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./Index");
            }
        }
    }
}
