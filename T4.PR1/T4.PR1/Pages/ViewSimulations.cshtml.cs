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
    }
}
