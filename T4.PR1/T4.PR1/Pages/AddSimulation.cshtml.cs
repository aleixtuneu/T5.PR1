using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using T4.PR1.Data;
using T4.PR1.Model;

namespace T4.PR1.Pages
{
    public class AddSimulationModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        public AddSimulationModel(EcoEnergyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EnergySimulation NewSimulation { get; set; }

        public string ErrorMessage;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Si us plau, omple tots els camps correctament.";
                return Page();
            }

            try
            {
                // Calcular energia generada abans d'inserir a la base de dades
                NewSimulation.EnergyGenerated = CalculateEnergy(NewSimulation);

                _context.Simulations.Add(NewSimulation);
                await _context.SaveChangesAsync();

                return RedirectToPage("ViewSimulations");
            }
            catch (Exception ex)
            {
                // Log the exception
                ErrorMessage = "Error en desar la simulació.";
                return Page();
            }
        }

        private decimal CalculateEnergy(EnergySimulation simulation)
        {
            AEnergySystem system = simulation.SystemType switch
            {
                "Solar" => new SolarSystem(simulation.Ratio),
                "Wind" => new WindSystem(simulation.Ratio),
                "Hydraulic" => new HydraulicSystem(simulation.Ratio),
                _ => throw new ArgumentException("Tipus de sistema invàlid.")
            };

            return system.CalculateEnergy(simulation.InputValue);
        }
    }
}
