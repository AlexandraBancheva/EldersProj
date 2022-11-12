using FluentMigrator;

namespace EldersGame.Persistence.Migrations
{
    [Migration(202211111515)]
    public class GenreInitialCreate : Migration
    {
        public override void Down()
        {
            Delete.Table("Genre");
        }

        public override void Up()
        {
            Create.Table("Genre")
               .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
               .WithColumn("IdGame").AsInt32().NotNullable().ForeignKey("Game", "Id");
        }
    }
}
