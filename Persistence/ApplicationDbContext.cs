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
        public DbSet<DetalleCarrito> DetalleCarrito { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
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
            modelBuilder.Entity<Pedido>().HasRequired(x => x.Email).WithMany().HasForeignKey(x => x.CorreoUsuario);
            modelBuilder.Entity<Direccion>().HasRequired(x => x.Email).WithMany().HasForeignKey(x => x.Correo);
            modelBuilder.Entity<DetalleCarrito>().HasRequired(x => x.Producto).WithMany().HasForeignKey(x => x.IdProducto);
            modelBuilder.Entity<DetalleCarrito>().HasRequired(x => x.Email).WithMany().HasForeignKey(x => x.Correo);
            modelBuilder.Entity<DetalleCarrito>().HasRequired(x => x.Pedido).WithMany().HasForeignKey(x => x.IdPedido);
            base.OnModelCreating(modelBuilder);
        }
    }
}
