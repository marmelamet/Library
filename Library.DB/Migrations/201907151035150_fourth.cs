namespace Library.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Raflar", "Turler_ID", c => c.Int());
            CreateIndex("dbo.Raflar", "Turler_ID");
            AddForeignKey("dbo.Raflar", "Turler_ID", "dbo.Turler", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Raflar", "Turler_ID", "dbo.Turler");
            DropIndex("dbo.Raflar", new[] { "Turler_ID" });
            DropColumn("dbo.Raflar", "Turler_ID");
        }
    }
}
