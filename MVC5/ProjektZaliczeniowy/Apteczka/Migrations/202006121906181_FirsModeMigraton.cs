namespace Apteczka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirsModeMigraton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LekModels",
                c => new
                    {
                        LekModelID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Kategoria = c.String(nullable: false),
                        Forma = c.String(nullable: false),
                        Producent = c.String(nullable: false),
                        Ilosc = c.Double(nullable: false),
                        TerminWaznosci = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LekModelID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LekModels");
        }
    }
}
