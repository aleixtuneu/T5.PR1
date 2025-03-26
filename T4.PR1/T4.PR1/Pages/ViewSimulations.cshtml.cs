using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using T4.PR1.Data;
using T4.PR1.Model;
using Microsoft.EntityFrameworkCore;

namespace T4.PR1.Pages
{
    public class ViewSimulationsModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        public ViewSimulationsModel(EcoEnergyContext context)
        {
            _context = context;
        }

        public List<EnergySimulation> Simulations { get; set; } = new List<EnergySimulation>();

        public async Task OnGetAsync()
        {
            Simulations = await _context.Simulations.ToListAsync();
        }

        public string FileErrorMessage { get; set; }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var simulationToDelete = await _context.Simulations.FindAsync(id);

                if (simulationToDelete == null)
                {
                    return NotFound();
                }

                _context.Simulations.Remove(simulationToDelete);
                await _context.SaveChangesAsync();

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                // Log 
                FileErrorMessage = "Error al eliminar la simulación: " + ex.Message;
                return Page();
            }
        }
    }
}
