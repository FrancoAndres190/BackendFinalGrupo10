using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendFinalGrupo10.Migrations
{
    public partial class AgendaG10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "a@gmail.com", "Ligorria", "Franco", "12345", "franco12345" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 2, "a@gmail.com", "Luciano", "Olivia", "12345", "olivia12345" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 3, "a@gmail.com", "Maranzana", "Agustin", "12345", "agustin12345" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Number", "UserId" },
                values: new object[] { 1, "Andrea", "(341) 155-544-333", 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Number", "UserId" },
                values: new object[] { 2, "Ariana", "(341) 155-222-333", 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Number", "UserId" },
                values: new object[] { 3, "Victor", "(341) 155-111-333", 2 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Number", "UserId" },
                values: new object[] { 4, "Carlos", "(341) 155-544-683", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
