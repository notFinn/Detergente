namespace Detergente.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacionesEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "FechaActualizacion", c => c.DateTime());
            AlterColumn("dbo.FamiliaTipoArticuloes", "NombreFamilia", c => c.String(maxLength: 50));
            AlterColumn("dbo.TipoProductoes", "NombreTipo", c => c.String(maxLength: 250));
            DropColumn("dbo.Productoes", "FechaIngreso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "FechaIngreso", c => c.DateTime());
            AlterColumn("dbo.TipoProductoes", "NombreTipo", c => c.String());
            AlterColumn("dbo.FamiliaTipoArticuloes", "NombreFamilia", c => c.String());
            DropColumn("dbo.Productoes", "FechaActualizacion");
        }
    }
}
