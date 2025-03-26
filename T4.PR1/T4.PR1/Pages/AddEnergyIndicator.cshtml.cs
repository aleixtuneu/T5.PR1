using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;
using T4.PR1.Model;
using Newtonsoft.Json;
using T4.PR1.Data;

namespace T4.PR1.Pages
{
    public class AddEnergyIndicatorModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        public AddEnergyIndicatorModel(EcoEnergyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EnergyIndicator NewEnergyIndicator { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.EnergyIndicators.Add(NewEnergyIndicator);
                await _context.SaveChangesAsync();

                return RedirectToPage("/ViewEnergyIndicators");
            }
            catch (Exception ex)
            {
                // Log de l'error
                ErrorMessage = "Error al desar l'indicador energètic.";
                return Page();
            }
        }
    }
}
