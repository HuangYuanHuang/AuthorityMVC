namespace Authority.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Purv_AppConfig",
                c => new
                    {
                        AppID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 250),
                        AddDateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AppID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_Purv_AppConfig");
        }
    }
}
