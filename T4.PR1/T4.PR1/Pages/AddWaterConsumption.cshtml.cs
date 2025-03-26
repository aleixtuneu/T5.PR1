using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using T4.PR1.Data;
using T4.PR1.Model;

namespace T4.PR1.Pages
{
    public class AddWaterConsumptionModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        public AddWaterConsumptionModel(EcoEnergyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WaterConsumption NewWaterConsumption { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.WaterConsumptions.Add(NewWaterConsumption);
                await _context.SaveChangesAsync();

                return RedirectToPage("/ViewWaterConsumptions");
            }
            catch (Exception ex)
            {
                // Log de l'error
                ModelState.AddModelError("", "Error al desar el consum d'aigua.");
                return Page();
            }
        }
    }
}
