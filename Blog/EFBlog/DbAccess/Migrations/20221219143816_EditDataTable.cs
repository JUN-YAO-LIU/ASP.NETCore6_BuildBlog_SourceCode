using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFBlog.Migrations
{
    public partial class EditDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthUsers",
                table: "AuthUsers");

            migrationBuilder.DropColumn(
                name: "代碼",
                table: "AuthUsers");

            migrationBuilder.RenameColumn(
                name: "帳號",
                table: "AuthUsers",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "密碼",
                table: "AuthUsers",
                newName: "Pwd");

            migrationBuilder.AlterColumn<string>(
                name: "Account",
                table: "AuthUsers",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "帳號",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Pwd",
                table: "AuthUsers",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "密碼",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthUsers",
                table: "AuthUsers",
                column: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthUsers",
                table: "AuthUsers");

            migrationBuilder.RenameColumn(
                name: "Pwd",
                table: "AuthUsers",
                newName: "密碼");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "AuthUsers",
                newName: "帳號");

            migrationBuilder.AlterColumn<string>(
                name: "密碼",
                table: "AuthUsers",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldComment: "密碼");

            migrationBuilder.AlterColumn<string>(
                name: "帳號",
                table: "AuthUsers",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldComment: "帳號");

            migrationBuilder.AddColumn<string>(
                name: "代碼",
                table: "AuthUsers",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthUsers",
                table: "AuthUsers",
                column: "代碼");
        }
    }
}
