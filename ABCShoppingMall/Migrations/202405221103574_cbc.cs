namespace ABCShoppingMall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cbc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Image");
        }
    }
}
