namespace switches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Switches", "Model", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Switches", "Ip", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Switches", "Mac", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Switches", "VLan", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Switches", "Serial", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Switches", "Serial", c => c.String());
            AlterColumn("dbo.Switches", "VLan", c => c.String());
            AlterColumn("dbo.Switches", "Mac", c => c.String());
            AlterColumn("dbo.Switches", "Ip", c => c.String());
            AlterColumn("dbo.Switches", "Model", c => c.String());
        }
    }
}
