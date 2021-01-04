using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoPartiiSchi.Data;
using InfoPartiiSchi.Models;

namespace InfoPartiiSchi.Pages.Partii
{
    public class DetailsModel : PageModel
    {
        private readonly InfoPartiiSchi.Data.ApplicationDbContext _context;

        public DetailsModel(InfoPartiiSchi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
