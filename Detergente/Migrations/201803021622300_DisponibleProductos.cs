namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisponibleProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Disponible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Disponible");
        }
    }
}
