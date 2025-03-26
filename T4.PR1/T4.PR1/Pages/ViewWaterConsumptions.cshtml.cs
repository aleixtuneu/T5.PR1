using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T4.PR1.Data;
using T4.PR1.Model;


namespace T4.PR1.Pages
{
    public class ViewWaterConsumptionsModel : PageModel
    {
		private readonly EcoEnergyContext _context;

		public ViewWaterConsumptionsModel(EcoEnergyContext context)
		{
			_context = context;
		}

		public List<WaterConsumption> WaterConsumptions { get; set; } = new List<WaterConsumption>();

		public string FileErrorMessage { get; set; }

		public async Task OnGetAsync()
		{
			WaterConsumptions = await _context.WaterConsumptions.ToListAsync();
		}

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
				// Log de l'error
				FileErrorMessage = "Error al eliminar el consum d'aigua: " + ex.Message;
				return Page();
			}
		}
	}
}
