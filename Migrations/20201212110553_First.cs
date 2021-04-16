using Microsoft.EntityFrameworkCore.Migrations;

namespace carshop.webui.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car_Brands",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(unicode: false, maxLength: 55, nullable: false, defaultValueSql: "('')"),
                    Brand_Name = table.Column<string>(unicode: false, maxLength: 55, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Car_Models",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_ID = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    Code = table.Column<string>(unicode: false, maxLength: 125, nullable: false, defaultValueSql: "('')"),
                    Model_Name = table.Column<string>(unicode: false, maxLength: 125, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_Models", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "General_Type",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "General_Info",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Type_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General_Info", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gen_Name_General_Type",
                        column: x => x.Type_ID,
                        principalTable: "General_Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_ADS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_ID = table.Column<int>(nullable: false),
                    Model_ID = table.Column<int>(nullable: false),
                    Body_Type_ID = table.Column<int>(nullable: false),
                    Walk = table.Column<int>(nullable: false),
                    Color_ID = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Currency_ID = table.Column<int>(nullable: false),
                    Credit = table.Column<bool>(nullable: false),
                    Barter = table.Column<bool>(nullable: false),
                    Fuel_Type_ID = table.Column<int>(nullable: false),
                    Transmission_ID = table.Column<int>(nullable: false),
                    Gearbox_ID = table.Column<int>(nullable: false),
                    Graduation_Year = table.Column<int>(nullable: false),
                    Engine_Capacity_ID = table.Column<int>(nullable: false),
                    HP = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 300, nullable: true),
                    Alloy_Wheels = table.Column<bool>(nullable: false),
                    Central_Closure = table.Column<bool>(nullable: false),
                    Leather_Salon = table.Column<bool>(nullable: false),
                    Seat_Ventilation = table.Column<bool>(nullable: false),
                    USA = table.Column<bool>(nullable: false),
                    Parking_Radar = table.Column<bool>(nullable: false),
                    Xenon = table.Column<bool>(nullable: false),
                    Luke = table.Column<bool>(nullable: false),
                    Conditioner = table.Column<bool>(nullable: false),
                    Rear_Camera = table.Column<bool>(nullable: false),
                    Rain_Sensor = table.Column<bool>(nullable: false),
                    Seat_Heating = table.Column<bool>(nullable: false),
                    Side_Curtains = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    City_ID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Body_TB_ADS",
                        column: x => x.Body_Type_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Car_Brands",
                        column: x => x.Brand_ID,
                        principalTable: "Car_Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_City_General_Type1",
                        column: x => x.City_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Color_General_Type",
                        column: x => x.Color_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Currency",
                        column: x => x.Currency_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Engine_General_Type1",
                        column: x => x.Engine_Capacity_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Fuel_General_Type",
                        column: x => x.Fuel_Type_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Gearbox_General_Type",
                        column: x => x.Gearbox_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Model_Car_Models",
                        column: x => x.Model_ID,
                        principalTable: "Car_Models",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ADS_Transmission_General_Type",
                        column: x => x.Transmission_ID,
                        principalTable: "General_Info",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdsImageUrls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(nullable: true),
                    AdsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdsImageUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdsImageUrls_TB_ADS_AdsId",
                        column: x => x.AdsId,
                        principalTable: "TB_ADS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdsImageUrls_AdsId",
                table: "AdsImageUrls",
                column: "AdsId");

            migrationBuilder.CreateIndex(
                name: "IX_General_Info_Type_ID",
                table: "General_Info",
                column: "Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Body_Type_ID",
                table: "TB_ADS",
                column: "Body_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Brand_ID",
                table: "TB_ADS",
                column: "Brand_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_City_ID",
                table: "TB_ADS",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Color_ID",
                table: "TB_ADS",
                column: "Color_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Currency_ID",
                table: "TB_ADS",
                column: "Currency_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Engine_Capacity_ID",
                table: "TB_ADS",
                column: "Engine_Capacity_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Fuel_Type_ID",
                table: "TB_ADS",
                column: "Fuel_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Gearbox_ID",
                table: "TB_ADS",
                column: "Gearbox_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Model_ID",
                table: "TB_ADS",
                column: "Model_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ADS_Transmission_ID",
                table: "TB_ADS",
                column: "Transmission_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdsImageUrls");

            migrationBuilder.DropTable(
                name: "TB_ADS");

            migrationBuilder.DropTable(
                name: "General_Info");

            migrationBuilder.DropTable(
                name: "Car_Brands");

            migrationBuilder.DropTable(
                name: "Car_Models");

            migrationBuilder.DropTable(
                name: "General_Type");
        }
    }
}
