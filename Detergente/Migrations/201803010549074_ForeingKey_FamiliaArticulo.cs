namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeingKey_FamiliaArticulo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TipoProductoes", "FamiliaTipoArticulo_Id", "dbo.FamiliaTipoArticuloes");
            DropIndex("dbo.TipoProductoes", new[] { "FamiliaTipoArticulo_Id" });
            RenameColumn(table: "dbo.TipoProductoes", name: "FamiliaTipoArticulo_Id", newName: "IdFamilia");
            AlterColumn("dbo.TipoProductoes", "IdFamilia", c => c.Int(nullable: false));
            CreateIndex("dbo.TipoProductoes", "IdFamilia");
            AddForeignKey("dbo.TipoProductoes", "IdFamilia", "dbo.FamiliaTipoArticuloes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoProductoes", "IdFamilia", "dbo.FamiliaTipoArticuloes");
            DropIndex("dbo.TipoProductoes", new[] { "IdFamilia" });
            AlterColumn("dbo.TipoProductoes", "IdFamilia", c => c.Int());
            RenameColumn(table: "dbo.TipoProductoes", name: "IdFamilia", newName: "FamiliaTipoArticulo_Id");
            CreateIndex("dbo.TipoProductoes", "FamiliaTipoArticulo_Id");
            AddForeignKey("dbo.TipoProductoes", "FamiliaTipoArticulo_Id", "dbo.FamiliaTipoArticuloes", "Id");
        }
    }
}
