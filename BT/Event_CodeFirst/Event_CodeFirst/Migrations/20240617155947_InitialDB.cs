using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_CodeFirst.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Conference" },
                    { 2, "Meetup" },
                    { 3, "Workshop" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserName", "Address", "Dob", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { "janedoe", "456 Oak St", new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe", "987-654-3210" },
                    { "johndoe", "123 Main St", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", "123-456-7890" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CreateAt", "CreatedBy", "Description", "EventTypeId", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 17, 22, 59, 46, 992, DateTimeKind.Local).AddTicks(3388), "johndoe", "Annual tech conference", 1, "Tech Conference 2024" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CreateAt", "CreatedBy", "Description", "EventTypeId", "Title" },
                values: new object[] { 2, new DateTime(2024, 6, 17, 22, 59, 46, 992, DateTimeKind.Local).AddTicks(3397), "janedoe", "Monthly local meetup", 2, "Local Meetup" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FId", "Description", "EventId", "Rate", "UserName" },
                values: new object[] { 1, "Great event!", 1, 5, "johndoe" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FId", "Description", "EventId", "Rate", "UserName" },
                values: new object[] { 2, "Very informative.", 1, 4, "janedoe" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "FId", "Description", "EventId", "Rate", "UserName" },
                values: new object[] { 3, "Looking forward to the next one.", 2, 5, "johndoe" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedBy",
                table: "Events",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_EventId",
                table: "Feedbacks",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
