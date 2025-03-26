using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4.PR1.Data;
using T4.PR1.Model;
using Microsoft.EntityFrameworkCore;

namespace T4.PR1.Pages
{
    /// <summary>
    /// Page model for displaying and managing energy simulations.
    /// </summary>
    public class ViewSimulationsModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        /// <summary>
        /// Constructor for the ViewSimulationsModel class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public ViewSimulationsModel(EcoEnergyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List of energy simulations to display.
        /// </summary>
        public List<EnergySimulation> Simulations { get; set; } = new List<EnergySimulation>();

        /// <summary>
        /// Handler for the GET request, retrieves the list of energy simulations from the database.
        /// </summary>
        public async Task OnGetAsync()
        {
            Simulations = await _context.Simulations.ToListAsync();
        }

        /// <summary>
        /// Error message related to file operations or other errors.
        /// </summary>
        public string FileErrorMessage { get; set; }

        /// <summary>
        /// Handler for the POST request to delete an energy simulation.
        /// </summary>
        /// <param name="id">ID of the energy simulation to delete.</param>
        /// <returns>IActionResult to redirect to the page or show an error.</returns>
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
                // 
                FileErrorMessage = "Error a l'eliminar la simulació: " + ex.Message;
                return Page();
            }
        }
    }
}
