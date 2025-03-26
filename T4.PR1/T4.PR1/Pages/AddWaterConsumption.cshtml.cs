using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using T4.PR1.Data;
using T4.PR1.Model;

namespace T4.PR1.Pages
{
    /// <summary>
    /// Page model for adding new water consumption.
    /// </summary>
    public class AddWaterConsumptionModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        /// <summary>
        /// Constructor for the AddWaterConsumptionModel class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public AddWaterConsumptionModel(EcoEnergyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Property bound to receive the new water consumption from the form.
        /// </summary>
        [BindProperty]
        public WaterConsumption NewWaterConsumption { get; set; }

        /// <summary>
        /// Handler for the GET request.
        /// </summary>
        /// <returns>IActionResult to display the page.</returns>
        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// Handler for the POST request, which saves the new water consumption to the database.
        /// </summary>
        /// <returns>IActionResult to redirect to the display page or show an error.</returns>
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
                // Error
                ModelState.AddModelError("", "Error al desar el consum d'aigua.");
                return Page();
            }
        }
    }
}
