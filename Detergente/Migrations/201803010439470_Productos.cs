namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamiliaTipoArticuloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreFamilia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 40),
                        Descripcion = c.String(maxLength: 250),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        dateTime = c.DateTime(),
                        TipoProducto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoProductoes", t => t.TipoProducto_Id)
                .Index(t => t.TipoProducto_Id);
            
            CreateTable(
                "dbo.TipoProductoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreTipo = c.String(),
                        FamiliaTipoArticulo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamiliaTipoArticuloes", t => t.FamiliaTipoArticulo_Id)
                .Index(t => t.FamiliaTipoArticulo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "TipoProducto_Id", "dbo.TipoProductoes");
            DropForeignKey("dbo.TipoProductoes", "FamiliaTipoArticulo_Id", "dbo.FamiliaTipoArticuloes");
            DropIndex("dbo.TipoProductoes", new[] { "FamiliaTipoArticulo_Id" });
            DropIndex("dbo.Productoes", new[] { "TipoProducto_Id" });
            DropTable("dbo.TipoProductoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.FamiliaTipoArticuloes");
        }
    }
}
