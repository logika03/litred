using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class SubType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonthPrice",
                table: "SubscriptionTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubscriptionOption",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SubscriptionTypeId = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionOption_SubscriptionTypes_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionOption_SubscriptionTypeId",
                table: "SubscriptionOption",
                column: "SubscriptionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionOption");

            migrationBuilder.DropColumn(
                name: "MonthPrice",
                table: "SubscriptionTypes");
        }
    }
}
