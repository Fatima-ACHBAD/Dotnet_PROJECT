using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mini1projet2.Models;

namespace mini1projet2.Data
{
    public class mini1projet2Context : DbContext
    {
        public mini1projet2Context (DbContextOptions<mini1projet2Context> options)
            : base(options)
        {
        }

        public DbSet<mini1projet2.Models.Panier> Panier { get; set; } = default!;

        public DbSet<mini1projet2.Models.Produit> Produit { get; set; }

        public DbSet<mini1projet2.Models.LignePanier> LignePanier { get; set; }
    }
}
