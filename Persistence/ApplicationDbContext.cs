using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        //DbSet Clases
        public DbSet<Producto> Producto { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<FamiliaTipoArticulo> FamiliaTipoArticulo { get; set; }
        //Fin DbSet

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<TipoProducto>().HasRequired(x => x.FamiliaTipoArticulo).WithMany().HasForeignKey(x => x.IdFamilia);
            modelBuilder.Entity<Producto>().HasRequired(x => x.TipoProducto).WithMany().HasForeignKey(x => x.IdTipoProducto);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>();
        }
    }
}
