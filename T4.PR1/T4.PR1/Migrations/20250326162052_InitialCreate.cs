using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T4.PR1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PBEE_Hydroelectric = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PBEE_Coal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PBEE_NaturalGas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PBEE_FuelOil = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PBEE_CombinedCycle = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PBEE_Nuclear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_GrossProduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_AuxiliaryConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_NetProduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_PumpConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_AvailableProduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_TotalSalesCentralGrid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_InterchangeBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_ElectricityDemand = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_TotalRegulatedMarket = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CDEEBC_TotalLiberalizedMarket = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEE_Industry = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEE_Tertiary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEE_Domestic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEE_Primary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEE_Energy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_PublicWorksConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_SteelFoundry = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_Metallurgy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_GlassIndustry = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_CementLimePlaster = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_OtherConstructionMaterials = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_ChemicalPetrochemical = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_TransportConstruction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_OtherMetalTransformation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_FoodBeverageTobacco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_TextileLeatherFootwear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_PaperPulpCardboard = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FEEI_OtherIndustries = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DGGN_FrontierEnagas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DGGN_GNLDistribution = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DGGN_NaturalGasConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CCAC_AutoGasoline = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CCAC_DieselA = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyIndicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SimulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ratio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnergyGenerated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPerKWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerKWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    HomeNetwork = table.Column<int>(type: "int", nullable: false),
                    EconomicActivities = table.Column<int>(type: "int", nullable: false),
                    TotalWaterConsumption = table.Column<int>(type: "int", nullable: false),
                    DomesticConsumptionPerCapita = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterConsumptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EnergyIndicators",
                columns: new[] { "Id", "CCAC_AutoGasoline", "CCAC_DieselA", "CDEEBC_AuxiliaryConsumption", "CDEEBC_AvailableProduction", "CDEEBC_ElectricityDemand", "CDEEBC_GrossProduction", "CDEEBC_InterchangeBalance", "CDEEBC_NetProduction", "CDEEBC_PumpConsumption", "CDEEBC_TotalLiberalizedMarket", "CDEEBC_TotalRegulatedMarket", "CDEEBC_TotalSalesCentralGrid", "DGGN_FrontierEnagas", "DGGN_GNLDistribution", "DGGN_NaturalGasConsumption", "Date", "FEEI_CementLimePlaster", "FEEI_ChemicalPetrochemical", "FEEI_FoodBeverageTobacco", "FEEI_GlassIndustry", "FEEI_Metallurgy", "FEEI_OtherConstructionMaterials", "FEEI_OtherIndustries", "FEEI_OtherMetalTransformation", "FEEI_PaperPulpCardboard", "FEEI_PublicWorksConsumption", "FEEI_SteelFoundry", "FEEI_TextileLeatherFootwear", "FEEI_TransportConstruction", "FEE_Domestic", "FEE_Energy", "FEE_Industry", "FEE_Primary", "FEE_Tertiary", "PBEE_Coal", "PBEE_CombinedCycle", "PBEE_FuelOil", "PBEE_Hydroelectric", "PBEE_NaturalGas", "PBEE_Nuclear" },
                values: new object[] { 1, 10m, 8m, 10m, 135m, 130m, 150m, 5m, 140m, 5m, 60m, 70m, 120m, 4m, 3m, 2m, "01/2023", 4m, 2m, 8m, 5m, 6m, 3m, 5m, 9m, 6m, 8m, 7m, 7m, 1m, 20m, 5m, 40m, 10m, 30m, 50m, 60m, 25m, 100m, 75m, 80m });

            migrationBuilder.InsertData(
                table: "Simulations",
                columns: new[] { "Id", "CostPerKWh", "EnergyGenerated", "InputValue", "PricePerKWh", "Ratio", "SimulationDate", "SystemType" },
                values: new object[] { 1, 0.1m, 10m, 5m, 0.2m, 2m, new DateTime(2025, 3, 26, 17, 20, 50, 300, DateTimeKind.Local).AddTicks(9843), "Solar" });

            migrationBuilder.InsertData(
                table: "WaterConsumptions",
                columns: new[] { "Id", "Code", "County", "DomesticConsumptionPerCapita", "EconomicActivities", "HomeNetwork", "Population", "TotalWaterConsumption", "Year" },
                values: new object[] { 1, 1, "Barcelona", 10m, 200, 500, 1000, 10000, 2023 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyIndicators");

            migrationBuilder.DropTable(
                name: "Simulations");

            migrationBuilder.DropTable(
                name: "WaterConsumptions");
        }
    }
}
