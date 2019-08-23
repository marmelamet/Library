namespace Library.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kullanicilar", "TCKimlik", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kullanicilar", "TCKimlik", c => c.String(nullable: false));
        }
    }
}
