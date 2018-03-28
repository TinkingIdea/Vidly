namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Ss", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Ss");
        }
    }
}
