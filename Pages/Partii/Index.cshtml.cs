﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly InfoPartiiSchi.Data.ApplicationDbContext _context;

        public IndexModel(InfoPartiiSchi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Partie> Partie { get;set; }

        public async Task OnGetAsync()
        {
            Partie = await _context.Partie
                .Include(p => p.Statiune).ToListAsync();
        }
    }
}