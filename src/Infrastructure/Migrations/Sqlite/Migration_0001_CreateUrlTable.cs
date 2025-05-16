namespace Infrastructure.Migrations.Sqlite;

[Migration(1)]
public class Migration_0001_CreateUrlTable : Migration
{
    public override void Up()
    {
        Create.Table("Urls")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Alias").AsString(255).NotNullable()
            .WithColumn("Original").AsString(2048).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Urls");
    }
}
