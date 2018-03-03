namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollbackCarrito : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carritoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetalleOrdens", "OrdenId", "dbo.Ordens");
            DropForeignKey("dbo.DetalleOrdens", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.Carritoes", new[] { "ProductoId" });
            DropIndex("dbo.DetalleOrdens", new[] { "OrdenId" });
            DropIndex("dbo.DetalleOrdens", new[] { "ProductoId" });
            DropTable("dbo.Carritoes");
            DropTable("dbo.DetalleOrdens");
            DropTable("dbo.Ordens");
        }
        
        public override void Down()
        {
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
            
            CreateTable(
                "dbo.DetalleOrdens",
                c => new
                    {
                        DetalleOrdenId = c.Int(nullable: false, identity: true),
                        OrdenId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DetalleOrdenId);
            
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        GuardarId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GuardarId);
            
            CreateIndex("dbo.DetalleOrdens", "ProductoId");
            CreateIndex("dbo.DetalleOrdens", "OrdenId");
            CreateIndex("dbo.Carritoes", "ProductoId");
            AddForeignKey("dbo.DetalleOrdens", "ProductoId", "dbo.Productoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DetalleOrdens", "OrdenId", "dbo.Ordens", "OrdenId", cascadeDelete: true);
            AddForeignKey("dbo.Carritoes", "ProductoId", "dbo.Productoes", "Id", cascadeDelete: true);
        }
    }
}
