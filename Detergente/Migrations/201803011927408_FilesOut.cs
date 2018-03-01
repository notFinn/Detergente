namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilesOut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.Files", new[] { "ProductoId" });
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateIndex("dbo.Files", "ProductoId");
            AddForeignKey("dbo.Files", "ProductoId", "dbo.Productoes", "Id", cascadeDelete: true);
        }
    }
}
