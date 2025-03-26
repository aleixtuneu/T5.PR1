using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T4.PR1.Data;
using T4.PR1.Model;

namespace T4.PR1.Pages
{
    /// <summary>
    /// Page model for displaying and managing energy indicators.
    /// </summary>
    public class ViewEnergyIndicatorsModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        /// <summary>
        /// Constructor for the ViewEnergyIndicatorsModel class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public ViewEnergyIndicatorsModel(EcoEnergyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List of energy indicators to display.
        /// </summary>
        public List<EnergyIndicator> EnergyIndicators { get; set; } = new List<EnergyIndicator>();

        /// <summary>
        /// Error message related to file operations or other errors.
        /// </summary>
        public string FileErrorMessage { get; set; }

        /// <summary>
        /// Handler for the GET request, retrieves the list of energy indicators from the database.
        /// </summary>
        public async Task OnGetAsync()
        {
            EnergyIndicators = await _context.EnergyIndicators.ToListAsync();
        }

        /// <summary>
        /// Handler for the POST request to delete an energy indicator.
        /// </summary>
        /// <param name="id">ID of the energy indicator to delete.</param>
        /// <returns>IActionResult to redirect to the page or show an error.</returns>
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var energyIndicatorToDelete = await _context.EnergyIndicators.FindAsync(id);

                if (energyIndicatorToDelete == null)
                {
                    return NotFound();
                }

                _context.EnergyIndicators.Remove(energyIndicatorToDelete);
                await _context.SaveChangesAsync();

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                // Error Message
                FileErrorMessage = "Error a l'eliminar l'indicador energètic: " + ex.Message;
                return Page();
            }
        }
    }
}