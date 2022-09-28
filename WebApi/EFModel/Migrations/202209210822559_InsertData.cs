namespace EFModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertData : DbMigration
    {
        public override void Up()
        {
            Sql(
                "INSERT INTO jobs (date,ActiveJobs,ComulativeJobView,ComulativePredictedeJobView) VALUES " +
                "('2022-09-01', 10, 30, 24),"+
                "('2022-09-02', 45, 35, 12),"+
                "('2022-09-03', 56, 2, 90),"+
                "('2022-09-04', 43, 30, 4),"+
                "('2022-09-05', 34, 23, 24),"+
                "('2022-09-06', 13, 10, 74),"+
                "('2022-09-07', 90, 60, 34),"+
                "('2022-09-08', 10, 33, 29),"+
                "('2022-09-09', 71, 37, 20),"+
                "('2022-09-10', 87, 30, 124),"+
                "('2022-09-11', 100, 30, 24),"+
                "('2022-09-12', 56, 60, 4),"+
                "('2022-09-13', 3, 54, 9)"
                );
        }
        
        public override void Down()
        {
        }
    }
}
