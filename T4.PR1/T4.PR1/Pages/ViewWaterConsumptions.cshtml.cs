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
			try
			{
				WaterConsumptions = await _context.WaterConsumptions.ToListAsync();
			}
			catch (Exception ex)
			{
				FileErrorMessage = "Error al carreegar les dades del consum d'aigua: " + ex.Message;

				// Registrar error amb un logger
			}
		}
    }
}
