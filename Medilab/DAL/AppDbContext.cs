using Medilab.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medilab.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        private DbContextOptions<AppDbContext> _options { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}