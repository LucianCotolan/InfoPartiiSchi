using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InfoPartiiSchi.Data;
using InfoPartiiSchi.Models;
using Microsoft.AspNetCore.Authorization;

namespace InfoPartiiSchi.Pages.Statiuni
{
    [Authorize(Roles ="Admin")]
    public class CreateModel : PageModel
    {
        private readonly InfoPartiiSchi.Data.ApplicationDbContext _context;

        public CreateModel(InfoPartiiSchi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Statiune Statiune { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Statiune.Add(Statiune);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
