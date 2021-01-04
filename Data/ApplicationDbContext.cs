using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InfoPartiiSchi.Models;

namespace InfoPartiiSchi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InfoPartiiSchi.Models.Statiune> Statiune { get; set; }
        public DbSet<InfoPartiiSchi.Models.Partie> Partie { get; set; }
    }
}
