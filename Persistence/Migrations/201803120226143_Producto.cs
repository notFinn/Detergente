namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Producto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producto", "Precio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producto", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
