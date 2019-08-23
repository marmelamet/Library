namespace Library.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RafAndTur : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Raflar", "turID", c => c.Int(nullable: false));
            CreateIndex("dbo.Raflar", "turID");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Raflar", "turID", c => c.Int());
            DropIndex("dbo.Raflar", "turID");
        }
    }
}
