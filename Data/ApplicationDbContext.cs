using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxiWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SampleTable> SampleTable { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
