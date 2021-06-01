using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class changeBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSubscriptionType");

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionTypeId",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubscriptionTypeId",
                table: "Books",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_SubscriptionTypes_SubscriptionTypeId",
                table: "Books",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_SubscriptionTypes_SubscriptionTypeId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_SubscriptionTypeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookSubscriptionType",
                columns: table => new
                {
                    BooksId = table.Column<string>(type: "text", nullable: false),
                    SubscriptionTypesId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubscriptionType", x => new { x.BooksId, x.SubscriptionTypesId });
                    table.ForeignKey(
                        name: "FK_BookSubscriptionType_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubscriptionType_SubscriptionTypes_SubscriptionTypesId",
                        column: x => x.SubscriptionTypesId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSubscriptionType_SubscriptionTypesId",
                table: "BookSubscriptionType",
                column: "SubscriptionTypesId");
        }
    }
}
