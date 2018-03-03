using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Detergente.Models.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Detergente.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public DateTime? FechaNacimiento { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //DbSet Clases
        public DbSet<Producto> Producto { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
        public DbSet<FamiliaTipoArticulo> FamiliaTipoArticulo { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<DetalleOrden> DetalleOrden { get; set; }
        //Fin DbSet

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProducto>().HasRequired(x => x.FamiliaTipoArticulo).WithMany().HasForeignKey(x => x.IdFamilia);
            modelBuilder.Entity<Producto>().HasRequired(x => x.TipoProducto).WithMany().HasForeignKey(x => x.IdTipoProducto);
            base.OnModelCreating(modelBuilder);
        }
    }
}