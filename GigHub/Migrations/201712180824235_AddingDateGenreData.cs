namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDateGenreData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id,Name) values(1,'JAZZ')");
            Sql("Insert into Genres (Id,Name) values(2,'Balu')");
            Sql("Insert into Genres (Id,Name) values(3,'Deepa')");
            Sql("Insert into Genres (Id,Name) values(4,'Sad')");
            Sql("Insert into Genres (Id,Name) values(5,'Ram')");
        }
        
        public override void Down()
        {
            Sql("Delete from Genres where Id IN(1,2,3,4,5)");
        }
    }
}
