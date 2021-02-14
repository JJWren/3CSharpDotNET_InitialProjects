using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class AnotherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Users_UserID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Wedding_WeddingID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Wedding_Users_UserID",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Wedding",
                newName: "Weddings");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_Wedding_UserID",
                table: "Weddings",
                newName: "IX_Weddings_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Event_WeddingID",
                table: "Events",
                newName: "IX_Events_WeddingID");

            migrationBuilder.RenameIndex(
                name: "IX_Event_UserID",
                table: "Events",
                newName: "IX_Events_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings",
                column: "WeddingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserID",
                table: "Events",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Weddings_WeddingID",
                table: "Events",
                column: "WeddingID",
                principalTable: "Weddings",
                principalColumn: "WeddingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserID",
                table: "Weddings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Weddings_WeddingID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserID",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weddings",
                table: "Weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Weddings",
                newName: "Wedding");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_Weddings_UserID",
                table: "Wedding",
                newName: "IX_Wedding_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_WeddingID",
                table: "Event",
                newName: "IX_Event_WeddingID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_UserID",
                table: "Event",
                newName: "IX_Event_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wedding",
                table: "Wedding",
                column: "WeddingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Users_UserID",
                table: "Event",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Wedding_WeddingID",
                table: "Event",
                column: "WeddingID",
                principalTable: "Wedding",
                principalColumn: "WeddingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wedding_Users_UserID",
                table: "Wedding",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
