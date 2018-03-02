namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewImageTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "ImagePath");
        }
    }
}
