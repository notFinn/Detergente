namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoDeCompra : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        GuardarId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductoId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GuardarId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.DetalleOrdens",
                c => new
                    {
                        DetalleOrdenId = c.Int(nullable: false, identity: true),
                        OrdenId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DetalleOrdenId)
                .ForeignKey("dbo.Ordens", t => t.OrdenId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.OrdenId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Ordens",
                c => new
                    {
                        OrdenId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaOrden = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleOrdens", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleOrdens", "OrdenId", "dbo.Ordens");
            DropForeignKey("dbo.Carritoes", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.DetalleOrdens", new[] { "ProductoId" });
            DropIndex("dbo.DetalleOrdens", new[] { "OrdenId" });
            DropIndex("dbo.Carritoes", new[] { "ProductoId" });
            DropTable("dbo.Ordens");
            DropTable("dbo.DetalleOrdens");
            DropTable("dbo.Carritoes");
        }
    }
}
