namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieEdit1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Ss");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Ss", c => c.Int(nullable: false));
        }
    }
}
