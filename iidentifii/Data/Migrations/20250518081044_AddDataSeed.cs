using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iidentifii.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Likes", "PostUserId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "This is the content of the first post.", 0, 1, "First Post", null },
                    { 2, "This is the content of the second post.", 0, 1, "Second Post", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);
        }
    }
}
