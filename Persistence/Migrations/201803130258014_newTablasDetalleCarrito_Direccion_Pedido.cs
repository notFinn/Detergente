namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTablasDetalleCarrito_Direccion_Pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleCarrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        Precio = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        IdPedido = c.Int(nullable: false),
                        Correo = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Correo, cascadeDelete: false)
                .ForeignKey("dbo.Pedido", t => t.IdPedido, cascadeDelete: false)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: false)
                .Index(t => t.IdProducto)
                .Index(t => t.IdPedido)
                .Index(t => t.Correo);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CorreoUsuario = c.String(nullable: false, maxLength: 128),
                        Total = c.Int(nullable: false),
                        Despacho = c.Boolean(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CorreoUsuario, cascadeDelete: true)
                .Index(t => t.CorreoUsuario);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Latidud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        Comuna = c.String(),
                        Numero = c.Int(nullable: false),
                        Correo = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Correo, cascadeDelete: true)
                .Index(t => t.Correo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccion", "Correo", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetalleCarrito", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleCarrito", "IdPedido", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "CorreoUsuario", "dbo.AspNetUsers");
            DropForeignKey("dbo.DetalleCarrito", "Correo", "dbo.AspNetUsers");
            DropIndex("dbo.Direccion", new[] { "Correo" });
            DropIndex("dbo.Pedido", new[] { "CorreoUsuario" });
            DropIndex("dbo.DetalleCarrito", new[] { "Correo" });
            DropIndex("dbo.DetalleCarrito", new[] { "IdPedido" });
            DropIndex("dbo.DetalleCarrito", new[] { "IdProducto" });
            DropTable("dbo.Direccion");
            DropTable("dbo.Pedido");
            DropTable("dbo.DetalleCarrito");
        }
    }
}
