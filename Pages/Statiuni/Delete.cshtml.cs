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

namespace InfoPartiiSchi.Pages.Statiuni
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
        public Statiune Statiune { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Statiune = await _context.Statiune.FirstOrDefaultAsync(m => m.ID == id);

            if (Statiune == null)
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

            Statiune = await _context.Statiune.FindAsync(id);

            if (Statiune != null)
            {
                _context.Statiune.Remove(Statiune);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
