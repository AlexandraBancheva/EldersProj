//using FluentMigrator;

//namespace EldersGame.Persistence.Migrations
//{
//    [Migration(202211112200)]
//    public class GenreGameInitialCreate : Migration
//    {
//        public override void Down()
//        {
//            Delete.Table("GenreGame");
//        }

//        public override void Up()
//        {
//            Create.Table("GenreGame")
//                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
//                .WithColumn("IdGame").AsInt32().NotNullable().ForeignKey("Game", "Id")
//                .WithColumn("IdGenre").AsInt32().NotNullable().ForeignKey("Genre", "Id");
//        }
//    }
//}
