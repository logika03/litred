using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Subscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubscriptionTypes_SubscriptionTypeId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SubscriptionTypeId",
                table: "AspNetUsers",
                newName: "SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SubscriptionTypeId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SubscriptionId");

            migrationBuilder.CreateTable(
                name: "SubscriptionStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SubscriptionTypeId = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SubscriptionStatusId = table.Column<string>(type: "text", nullable: true),
                    WeekCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId",
                        column: x => x.SubscriptionStatusId,
                        principalTable: "SubscriptionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionTypes_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionStatusId",
                table: "Subscriptions",
                column: "SubscriptionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionTypeId",
                table: "Subscriptions",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Subscriptions_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Subscriptions_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "SubscriptionStatuses");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "AspNetUsers",
                newName: "SubscriptionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubscriptionTypes_SubscriptionTypeId",
                table: "AspNetUsers",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
