namespace Library.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kullanicilar", "TCKimlik", c => c.String(nullable: false));
            AlterColumn("dbo.Kullanicilar", "adres", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kullanicilar", "adres", c => c.String(maxLength: 250));
            AlterColumn("dbo.Kullanicilar", "TCKimlik", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
