using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzeria.Migrations
{
    /// <inheritdoc />
    public partial class HaHaHA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fillings",
                columns: table => new
                {
                    IdFilling = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameFilling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceFilling = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fillings", x => x.IdFilling);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    IDPizza = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaPrice = table.Column<double>(type: "float", nullable: false),
                    PizzaImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDSauce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.IDPizza);
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    IDSauce = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameSauce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceSause = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.IDSauce);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    IDWorker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.IDWorker);
                });

            migrationBuilder.CreateTable(
                name: "Cockers",
                columns: table => new
                {
                    IDWorker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false),
                    HasFoodSafetyTraining = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cockers", x => x.IDWorker);
                    table.ForeignKey(
                        name: "FK_Cockers_Workers_IDWorker",
                        column: x => x.IDWorker,
                        principalTable: "Workers",
                        principalColumn: "IDWorker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    IDWorker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasLeadershipExperience = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.IDWorker);
                    table.ForeignKey(
                        name: "FK_Directors_Workers_IDWorker",
                        column: x => x.IDWorker,
                        principalTable: "Workers",
                        principalColumn: "IDWorker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    IDWorker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasLeadershipTraining = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.IDWorker);
                    table.ForeignKey(
                        name: "FK_Managers_Workers_IDWorker",
                        column: x => x.IDWorker,
                        principalTable: "Workers",
                        principalColumn: "IDWorker",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cockers");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Fillings");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
