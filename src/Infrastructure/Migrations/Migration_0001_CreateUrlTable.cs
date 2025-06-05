namespace Infrastructure.Migrations;

[Migration(1)]
public class Migration_0001_CreateUrlTable : Migration
{
    public override void Up()
    {
        Create.Table("urls")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("alias").AsString(255).NotNullable()
            .WithColumn("original").AsString(2048).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("urls");
    }
}
