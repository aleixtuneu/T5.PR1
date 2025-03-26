using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T4.PR1.Data;
using T4.PR1.Model;


namespace T4.PR1.Pages
{
    /// <summary>
    /// Page model for displaying and managing water consumptions.
    /// </summary>
    public class ViewWaterConsumptionsModel : PageModel
    {
		private readonly EcoEnergyContext _context;

        /// <summary>
        /// Constructor for the ViewWaterConsumptionsModel class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public ViewWaterConsumptionsModel(EcoEnergyContext context)
		{
			_context = context;
		}

        /// <summary>
        /// List of water consumptions to display.
        /// </summary
        public List<WaterConsumption> WaterConsumptions { get; set; } = new List<WaterConsumption>();

        /// <summary>
        /// Error message related to file operations or other errors.
        /// </summary>
        public string FileErrorMessage { get; set; }

        /// <summary>
        /// Handler for the GET request, retrieves the list of water consumptions from the database.
        /// </summary>
        public async Task OnGetAsync()
		{
			WaterConsumptions = await _context.WaterConsumptions.ToListAsync();
		}

        /// <summary>
        /// Handler for the POST request to delete a water consumption entry.
        /// </summary>
        /// <param name="id">ID of the water consumption entry to delete.</param>
        /// <returns>IActionResult to redirect to the page or show an error.</returns>
        public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			try
			{
				var waterConsumptionToDelete = await _context.WaterConsumptions.FindAsync(id);

				if (waterConsumptionToDelete == null)
				{
					return NotFound();
				}

				_context.WaterConsumptions.Remove(waterConsumptionToDelete);
				await _context.SaveChangesAsync();

				return RedirectToPage();
			}
			catch (Exception ex)
			{
				// Error message
				FileErrorMessage = "Error a l'eliminar el consum d'aigua: " + ex.Message;
				return Page();
			}
		}
	}
}
