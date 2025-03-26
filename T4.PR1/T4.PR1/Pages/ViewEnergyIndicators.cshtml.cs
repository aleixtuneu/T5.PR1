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
            try
            {
                EnergyIndicators = await _context.EnergyIndicators.ToListAsync();
            }
            catch (Exception ex)
            {
                FileErrorMessage = "Error al carregar els indicadors energètics: " + ex.Message;
                // Registrar l'error amb un logger
            }
        }
    }
}