using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using T4.PR1.Data;
using T4.PR1.Model;

namespace T4.PR1.Pages
{
    public class ViewEnergyIndicatorsModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        public ViewEnergyIndicatorsModel(EcoEnergyContext context)
        {
            _context = context;
        }

        public List<EnergyIndicator> EnergyIndicators { get; set; } = new List<EnergyIndicator>();

        public string FileErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            EnergyIndicators = await _context.EnergyIndicators.ToListAsync();
        }

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
                // Log 
                FileErrorMessage = "Error al eliminar l'indicador energètic: " + ex.Message;
                return Page();
            }
        }
    }
}