using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFBlog.Migrations
{
    public partial class AddDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    代碼 = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    帳號 = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    密碼 = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.代碼);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AuthUsers");
        }
    }
}
