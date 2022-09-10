using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImparApp.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base64 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "Base64" },
                values: new object[,]
                {
                    { 1, "iVBORw0KGgoAAAANSUhEUgAAABcAAAAOCAIAAABLkRCkAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAEESURBVDhPhZI/CsIwFIer4OIkeADByc2xl+ghegnBzd0r6NoDuHgBB3Hq4uBWsE6C0ojY+KeNL74Q40tawze0SX4f773W6y8Cm3Dlp8e2uHgmPGuONkNyE3FYQMHOLaLQgN12/VicJQBx2iE7xKUszny066nT9SS7H0SRiDw0L2iXtDhbMBXscRWf9Sw4uYbDkhZShc4TBawoWcLmNB6Y90EkqxLMka9SqKOVn51U+et9V+URc2b1CnMCshb9okHXkZ+VoFYBQAdyLqRPpCzzvwo9ge//Ql18DIrrbYY9Qr7mI3wtiF0XtD3f9u0uzBS1IMRVGs8AUQBuC6JdL9aoyksWwRvMhyA+ywOm9QAAAABJRU5ErkJggg==" },
                    { 2, "iVBORw0KGgoAAAANSUhEUgAAABcAAAAOCAYAAADE84fzAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsIAAA7CARUoSoAAAAI7SURBVDhPY1Ta6POfAQewE3rN0Kx+mUGG4xtUBAF+/mNiqL2py7D2hSxUBBPgNBxk8ETtcwx8LL+hItjBkx9cDJPuq0ItYYQI/gcaCWQyQXgIADL0oOU+hvn6J1EMPnXBkqGgcSbDrO3hUBEIAPmqS/MigwT7DyAP5E6IwSAC7nJcQQAytHlGHcPnd6JgPiPLP4YNa6UY+EEW/2pkYPi9ACw+46EKQ/c9DTAbBsAuhwUBNoNrJnTADQaB/3+YGPjZpIE6FRj+sM2AijIwZMjfYShVugHlQQDYcJCL0YPAN2M7Q1nbZIZf37ihohDg542wqHf7EQab5L0Mnuk7GHYc8AVbcNdxC9wSxsevuP7LsANdDI2LZc/kGaZXLWRg/sYDEUACIIOLcuTA7M6texm2zuZgYPrJAeYzsvxh2LDQloGfFeLIEx+EGZjAQQE1GARAQcT6ix3KgwAPT0GGA9uNcRoMAu4Om+EGg4Ah33sG5tuelg0M/xkZtHg/gQVBwcPK/Jfh7GUzMN/Vg4+hKl8FzAYBbAZ7uKxnqEhrhfIgYNVzOURqkeH4zpCncIshWPIxWBIG/vN8Z2BkhBhEjMGgYAVlLhCAp/MnPzgZKm/oQXkIwAhKbkDw9fschn1L/qIY7Oe2FqfBIICSif4CA195vw9D912k9Pqrg4HhMyMD959UhmjPFVBBiMFFKe1QHqbBIIC3bMmQA6ZdZdS0C1KMFP9ggM1gEMBrOAwgW/IXGPnMjBAtuAyFAAYGAFMy3QDXGPpUAAAAAElFTkSuQmCC" },
                    { 3, "iVBORw0KGgoAAAANSUhEUgAAABcAAAAOCAYAAADE84fzAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsIAAA7CARUoSoAAAABpSURBVDhPY7T1P/Kf6ScHAy0AE60MBgEmKE0TQCPD/4NJKhsOMpQRiqluOMg4iKtBgAYuRwDG/5/QRMgAb36xM3Az/2HgZP4LFWFg+PmPiTqGYwNf/7LQznAQoFFShIDhZjgkD1AIGBgAfK0ZLrSxEjMAAAAASUVORK5CYII=" },
                    { 4, "iVBORw0KGgoAAAANSUhEUgAAABwAAAARCAYAAADOk8xKAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAADgSURBVEhLY3wro/KfgY6ACUrTDQxuC1kd7Bj4d21hEDh5mIF//04G9tAgqAzxgKQ4FDh3jIFJVBTKY2D4//Mnw3sVHSiPOECSD5EtAwFGdnYoi3hAtIWg4KQGwBmkIAu425sYmGSkoSKEwb8nTxm+901i+Ll6HVQEE+C0UPD8CQZGEWEoj3jw/88fhveKmlAeJsAdpKwsUAZpgJGREcrCDnBa+H36bCiLNPBz2SooCzsgKVsIPb4NZSHAO1lVKIs4QFK2AOU7SgFJFn7vnwxlQcDPxcuhLOLBaG1BZcDAAADVVTd/arIdowAAAABJRU5ErkJggg==" },
                    { 5, "iVBORw0KGgoAAAANSUhEUgAAABcAAAAOCAYAAADE84fzAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsQAAA7EAZUrDhsAAABGSURBVDhPY/wPBAw0AkxQmiZg6BqON8zfyapCWbiB0OPbUBYmGNhgYZKVgbJIBwQN//f4CZRFOhimqYVSMHSDhYaGMzAAAE83Eg4T1IkNAAAAAElFTkSuQmCC" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Name", "PhotoId", "Status" },
                values: new object[,]
                {
                    { 1, "Card 1", 1, "Status 1" },
                    { 2, "Card 2", 2, "Status 2" },
                    { 3, "Card 3", 3, "Status 3" },
                    { 4, "Card 4", 4, "Status 4" },
                    { 5, "Card 5", 5, "Status 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PhotoId",
                table: "Cards",
                column: "PhotoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
