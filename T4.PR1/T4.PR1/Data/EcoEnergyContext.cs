using Microsoft.EntityFrameworkCore;
using T4.PR1.Model;

namespace T4.PR1.Data
{
    public class EcoEnergyContext : DbContext
    {
        public EcoEnergyContext(DbContextOptions<EcoEnergyContext> options) : base(options) { }

        public DbSet<EnergySimulation> Simulations { get; set; }
        public DbSet<WaterConsumption> WaterConsumptions { get; set; }
        public DbSet<EnergyIndicator> EnergyIndicators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relacions

            // Configurar el seed de dades

            modelBuilder.Entity<EnergySimulation>().HasData(
                new EnergySimulation { Id = 1, SystemType = "Solar", InputValue = 5, Ratio = 2, EnergyGenerated = 10, CostPerKWh = 0.1m, PricePerKWh = 0.2m, SimulationDate = DateTime.Now }
            );

            modelBuilder.Entity<WaterConsumption>().HasData(
                new WaterConsumption { Id = 1, Year = 2023, Code = 1, County = "Barcelona", Population = 1000, HomeNetwork = 500, EconomicActivities = 200, TotalWaterConsumption = 10000, DomesticConsumptionPerCapita = 10 }
            );

            modelBuilder.Entity<EnergyIndicator>().HasData(
                new EnergyIndicator { Id = 1, Date = "01/2023", PBEE_Hydroelectric = 100, PBEE_Coal = 50, PBEE_NaturalGas = 75, PBEE_FuelOil = 25, PBEE_CombinedCycle = 60, PBEE_Nuclear = 80, CDEEBC_GrossProduction = 150, CDEEBC_AuxiliaryConsumption = 10, CDEEBC_NetProduction = 140, CDEEBC_PumpConsumption = 5, CDEEBC_AvailableProduction = 135, CDEEBC_TotalSalesCentralGrid = 120, CDEEBC_InterchangeBalance = 5, CDEEBC_ElectricityDemand = 130, CDEEBC_TotalRegulatedMarket = 70, CDEEBC_TotalLiberalizedMarket = 60, FEE_Industry = 40, FEE_Tertiary = 30, FEE_Domestic = 20, FEE_Primary = 10, FEE_Energy = 5, FEEI_PublicWorksConsumption = 8, FEEI_SteelFoundry = 7, FEEI_Metallurgy = 6, FEEI_GlassIndustry = 5, FEEI_CementLimePlaster = 4, FEEI_OtherConstructionMaterials = 3, FEEI_ChemicalPetrochemical = 2, FEEI_TransportConstruction = 1, FEEI_OtherMetalTransformation = 9, FEEI_FoodBeverageTobacco = 8, FEEI_TextileLeatherFootwear = 7, FEEI_PaperPulpCardboard = 6, FEEI_OtherIndustries = 5, DGGN_FrontierEnagas = 4, DGGN_GNLDistribution = 3, DGGN_NaturalGasConsumption = 2, CCAC_AutoGasoline = 10, CCAC_DieselA = 8 }
            );
        }
    }
}
