using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InfoPartiiSchi.Data;
using InfoPartiiSchi.Models;
using Microsoft.AspNetCore.Authorization;

namespace InfoPartiiSchi.Pages.Statiuni
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly InfoPartiiSchi.Data.ApplicationDbContext _context;

        public EditModel(InfoPartiiSchi.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Statiune).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatiuneExists(Statiune.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StatiuneExists(int id)
        {
            return _context.Statiune.Any(e => e.ID == id);
        }
    }
}
