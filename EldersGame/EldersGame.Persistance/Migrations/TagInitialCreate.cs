using FluentMigrator;

namespace EldersGame.Persistence.Migrations
{
    [Migration(202211111514)]
    public class TagInitialCreate : Migration
    {
        public override void Down()
        {
            Delete.Table("Tag");
        }

        public override void Up()
        {
            Create.Table("Tag")
                .WithColumn("Ïd").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ÏdGame").AsInt32().NotNullable().ForeignKey("Game", "Id");
        }
    }
}
