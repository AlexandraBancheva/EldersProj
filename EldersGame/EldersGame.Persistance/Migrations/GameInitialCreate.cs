using FluentMigrator;

namespace EldersGame.Persistence.Migrations
{
    [Migration(202211111513)]
    public class GameInitialCreate : Migration
    {
        public override void Down()
        {
            Delete.Table("Game");
        }

        public override void Up()
        {
            Create.Table("Game")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("TagId").AsInt32().NotNullable()
                .WithColumn("GenreId").AsInt32().NotNullable()
                .WithColumn("Price").AsDouble().Nullable();
        }
    }
}
