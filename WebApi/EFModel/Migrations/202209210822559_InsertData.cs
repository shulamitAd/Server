namespace EFModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertData : DbMigration
    {
        public override void Up()
        {
            Sql(" insert Jobs values (GETDATE(),10,23,67)");
        }
        
        public override void Down()
        {
        }
    }
}
