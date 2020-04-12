using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Acongrebility.Models;

namespace Acongrebility.Data
{
    public class AcongrebilityContext : DbContext
    {
        public AcongrebilityContext (DbContextOptions<AcongrebilityContext> options)
            : base(options)
        {

        }

        public DbSet<Congressmembers> Congressmembers { get; set; }

        public DbSet<Acongrebility.Models.Bills> Bills { get; set; }
    }
}
