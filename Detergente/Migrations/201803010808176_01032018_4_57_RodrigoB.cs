namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01032018_4_57_RodrigoB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "TipoProducto_Id", "dbo.TipoProductoes");
            DropIndex("dbo.Productoes", new[] { "TipoProducto_Id" });
            RenameColumn(table: "dbo.Productoes", name: "TipoProducto_Id", newName: "IdTipoProducto");
            AddColumn("dbo.Productoes", "FechaIngreso", c => c.DateTime());
            AlterColumn("dbo.Productoes", "Cantidad", c => c.Int());
            AlterColumn("dbo.Productoes", "IdTipoProducto", c => c.Int(nullable: false));
            CreateIndex("dbo.Productoes", "IdTipoProducto");
            AddForeignKey("dbo.Productoes", "IdTipoProducto", "dbo.TipoProductoes", "Id", cascadeDelete: true);
            DropColumn("dbo.Productoes", "dateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "dateTime", c => c.DateTime());
            DropForeignKey("dbo.Productoes", "IdTipoProducto", "dbo.TipoProductoes");
            DropIndex("dbo.Productoes", new[] { "IdTipoProducto" });
            AlterColumn("dbo.Productoes", "IdTipoProducto", c => c.Int());
            AlterColumn("dbo.Productoes", "Cantidad", c => c.Int(nullable: false));
            DropColumn("dbo.Productoes", "FechaIngreso");
            RenameColumn(table: "dbo.Productoes", name: "IdTipoProducto", newName: "TipoProducto_Id");
            CreateIndex("dbo.Productoes", "TipoProducto_Id");
            AddForeignKey("dbo.Productoes", "TipoProducto_Id", "dbo.TipoProductoes", "Id");
        }
    }
}
