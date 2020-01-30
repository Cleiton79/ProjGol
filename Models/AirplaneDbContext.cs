using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteGolCleiton.Models
{
    public class AirplaneDbContext:DbContext
    {
        public AirplaneDbContext(DbContextOptions<AirplaneDbContext> options) : base(options)
        { }
        public DbSet<Airplanes> Airplane { get; set; }
    }
}
