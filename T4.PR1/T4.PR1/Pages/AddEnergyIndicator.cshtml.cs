using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4.PR1.Model;
using T4.PR1.Data;

namespace T4.PR1.Pages
{
    /// <summary>
    /// Page model for adding a new energy indicator.
    /// </summary>
    public class AddEnergyIndicatorModel : PageModel
    {
        private readonly EcoEnergyContext _context;

        /// <summary>
        /// Constructor for the AddEnergyIndicatorModel class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public AddEnergyIndicatorModel(EcoEnergyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Property bound to receive the new energy indicator from the form.
        /// </summary>
        [BindProperty]
        public EnergyIndicator NewEnergyIndicator { get; set; }

        /// <summary>
        /// Property to store the error message to display in the view.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Handler for the POST request, which saves the new energy indicator to the database.
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
                _context.EnergyIndicators.Add(NewEnergyIndicator);
                await _context.SaveChangesAsync();

                return RedirectToPage("/ViewEnergyIndicators");
            }
            catch (Exception ex)
            {
                // Add error to ModelState
                ErrorMessage = "Error al desar l'indicador energètic.";
                return Page();
            }
        }
    }
}
