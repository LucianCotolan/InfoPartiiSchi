using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoPartiiSchi.Data;
using InfoPartiiSchi.Models;
using Microsoft.AspNetCore.Authorization;

namespace InfoPartiiSchi.Pages.Partii
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly InfoPartiiSchi.Data.ApplicationDbContext _context;

        public DeleteModel(InfoPartiiSchi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Partie Partie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Partie = await _context.Partie
                .Include(p => p.Statiune).FirstOrDefaultAsync(m => m.ID == id);

            if (Partie == null)
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

            Partie = await _context.Partie.FindAsync(id);

            if (Partie != null)
            {
                _context.Partie.Remove(Partie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
