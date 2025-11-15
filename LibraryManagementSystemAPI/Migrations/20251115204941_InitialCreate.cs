using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "CreatedOn", "DateOfBirth", "FirstName", "LastName", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("b399d7f0-adb2-4a48-8cd3-08694c00f2d8"), "Nigerian playwright.", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6671), null, "Wole", "Soyinka", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6671) },
                    { new Guid("d9b5a5b0-643b-407e-8272-ed42192c4c14"), "Nigerian novelist.", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6658), null, "Chinua", "Achebe", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6660) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedOn", "Description", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("2ee4f22b-477e-402e-b40e-6bc6e3948b99"), new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6946), "Fictional works", "Fiction", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6946) },
                    { new Guid("cdfec743-7e29-47ca-bd10-70ba89fdd262"), new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6950), "Dramatic works", "Drama", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6951) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "GenreId", "ISBN", "PublicationYear", "Title", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("6b300d26-edcb-4bc3-b158-8dd6cbd42549"), new Guid("d9b5a5b0-643b-407e-8272-ed42192c4c14"), new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6987), new Guid("2ee4f22b-477e-402e-b40e-6bc6e3948b99"), "9780385474542", 1958, "Things Fall Apart", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6987) },
                    { new Guid("d30d3b36-39da-4120-848a-09e25372e4ad"), new Guid("b399d7f0-adb2-4a48-8cd3-08694c00f2d8"), new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6993), new Guid("cdfec743-7e29-47ca-bd10-70ba89fdd262"), "9780393322996", 1975, "Death and the King's Horseman", new DateTime(2025, 11, 15, 20, 49, 40, 89, DateTimeKind.Utc).AddTicks(6993) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
