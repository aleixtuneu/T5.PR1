using Microsoft.EntityFrameworkCore;
using T4.PR1.Model;

namespace T4.PR1.Data
{
    /// <summary>
    /// Data context for the EcoEnergy application.
    /// Manages access to data for energy simulations, water consumption, and energy indicators.
    /// </summary>
    public class EcoEnergyContext : DbContext
    {
        /// <summary>
        /// Constructor that receives the context configuration options.
        /// </summary>
        /// <param name="options">Context configuration options.</param>
        public EcoEnergyContext(DbContextOptions<EcoEnergyContext> options) : base(options) { }

        /// <summary>
        /// Represents the table of energy simulations, water consmptions, and energy indicators in the database.
        /// </summary>
        public DbSet<EnergySimulation> Simulations { get; set; }
        public DbSet<WaterConsumption> WaterConsumptions { get; set; }
        public DbSet<EnergyIndicator> EnergyIndicators { get; set; }

        /// <summary>
        /// Configures the database model, defining relationships and seed data.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure seed data (initial data insertion)
            modelBuilder.Entity<EnergySimulation>().HasData(
                new EnergySimulation { Id = 1, SystemType = "Solar", InputValue = 5, Ratio = 2, EnergyGenerated = 10, CostPerKWh = 0.1m, PricePerKWh = 0.2m, SimulationDate = new DateTime(2024, 01, 01, 12, 00, 00) }
            );

            modelBuilder.Entity<WaterConsumption>().HasData(
                new WaterConsumption { Id = 1, Year = 2023, Code = 1, County = "Barcelona", Population = 1000, HomeNetwork = 500, EconomicActivities = 200, TotalWaterConsumption = 10000, DomesticConsumptionPerCapita = 10 }
            );

            modelBuilder.Entity<EnergyIndicator>().HasData(
                new EnergyIndicator { Id = 1, Date = "01/2023", PBEE_Hydroelectric = 100, PBEE_Coal = 50, PBEE_NaturalGas = 75, PBEE_FuelOil = 25, PBEE_CombinedCycle = 60, PBEE_Nuclear = 80, CDEEBC_GrossProduction = 150, CDEEBC_AuxiliaryConsumption = 10, CDEEBC_NetProduction = 140, CDEEBC_PumpConsumption = 5, CDEEBC_AvailableProduction = 135, CDEEBC_TotalSalesCentralGrid = 120, CDEEBC_InterchangeBalance = 5, CDEEBC_ElectricityDemand = 130, CDEEBC_TotalRegulatedMarket = 70, CDEEBC_TotalLiberalizedMarket = 60, FEE_Industry = 40, FEE_Tertiary = 30, FEE_Domestic = 20, FEE_Primary = 10, FEE_Energy = 5, FEEI_PublicWorksConsumption = 8, FEEI_SteelFoundry = 7, FEEI_Metallurgy = 6, FEEI_GlassIndustry = 5, FEEI_CementLimePlaster = 4, FEEI_OtherConstructionMaterials = 3, FEEI_ChemicalPetrochemical = 2, FEEI_TransportConstruction = 1, FEEI_OtherMetalTransformation = 9, FEEI_FoodBeverageTobacco = 8, FEEI_TextileLeatherFootwear = 7, FEEI_PaperPulpCardboard = 6, FEEI_OtherIndustries = 5, DGGN_FrontierEnagas = 4, DGGN_GNLDistribution = 3, DGGN_NaturalGasConsumption = 2, CCAC_AutoGasoline = 10, CCAC_DieselA = 8 }
            );

            // Configure the decimal data type for EnergySimulation properties
            modelBuilder.Entity<EnergySimulation>()
                .Property(e => e.CostPerKWh)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergySimulation>()
                .Property(e => e.EnergyGenerated)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergySimulation>()
                .Property(e => e.InputValue)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergySimulation>()
                .Property(e => e.PricePerKWh)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergySimulation>()
                .Property(e => e.Ratio)
                .HasColumnType("decimal(18, 2)");

            // Configure the decimal data type for WaterConsumption properties
            modelBuilder.Entity<WaterConsumption>()
                .Property(e => e.DomesticConsumptionPerCapita)
                .HasColumnType("decimal(18, 2)");

            // Configure the decimal data type for EnergyIndicator properties
            modelBuilder.Entity<EnergyIndicator>()
        .Property(e => e.CCAC_AutoGasoline)
        .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CCAC_DieselA)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_AuxiliaryConsumption)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_AvailableProduction)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_ElectricityDemand)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_GrossProduction)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_InterchangeBalance)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_NetProduction)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_PumpConsumption)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_TotalLiberalizedMarket)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_TotalRegulatedMarket)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.CDEEBC_TotalSalesCentralGrid)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.DGGN_FrontierEnagas)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.DGGN_GNLDistribution)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.DGGN_NaturalGasConsumption)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_CementLimePlaster)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_ChemicalPetrochemical)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_FoodBeverageTobacco)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_GlassIndustry)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_Metallurgy)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_OtherConstructionMaterials)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_OtherIndustries)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_OtherMetalTransformation)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_PaperPulpCardboard)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_PublicWorksConsumption)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_SteelFoundry)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_TextileLeatherFootwear)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEEI_TransportConstruction)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEE_Domestic)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEE_Energy)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEE_Industry)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEE_Primary)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.FEE_Tertiary)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.PBEE_Coal)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.PBEE_CombinedCycle)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.PBEE_FuelOil)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.PBEE_Hydroelectric)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.PBEE_NaturalGas)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EnergyIndicator>()
                .Property(e => e.PBEE_Nuclear)
                .HasColumnType("decimal(18, 2)");

        }
    }
}
