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

namespace InfoPartiiSchi.Pages.Partii
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly InfoPartiiSchi.Data.ApplicationDbContext _context;

        public CreateModel(InfoPartiiSchi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StatiuneID"] = new SelectList(_context.Set<Statiune>(), "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Partie Partie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Partie.Add(Partie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
