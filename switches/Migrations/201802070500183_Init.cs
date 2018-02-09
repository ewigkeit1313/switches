namespace switches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Switches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Ip = c.String(),
                        Mac = c.String(),
                        VLan = c.String(),
                        Serial = c.String(),
                        DateBuy = c.DateTime(nullable: false),
                        DateInstallation = c.DateTime(nullable: false),
                        Floor = c.Int(nullable: false),
                        Сomment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Switches");
        }
    }
}
