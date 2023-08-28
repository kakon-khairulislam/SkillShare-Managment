namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedusertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "type");
        }
    }
}
