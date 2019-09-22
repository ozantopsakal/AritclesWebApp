using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AritclesWebApp.Migrations
{
    public partial class initializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    PostedAt = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    SubTitle = table.Column<string>(nullable: true),
                    AllowsComments = table.Column<bool>(nullable: true),
                    ThumbnailPhoto = table.Column<string>(maxLength: 350, nullable: true),
                    Photo = table.Column<string>(maxLength: 350, nullable: true),
                    Language = table.Column<string>(maxLength: 2, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Comments_Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Language = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagsArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagId = table.Column<int>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 350, nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    UserTypes = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Bio", "CreatedAt", "Email", "Name", "Password", "Photo", "UserName", "UserTypes" },
                values: new object[] { 1, true, "", "22.9.2019 03:29:36", "admin@webarticles.com", "Admin", "@dM!n123", "", "admin", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TagsArticles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
