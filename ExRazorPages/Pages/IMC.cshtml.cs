using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExRazorPages.Pages
{
    public class IMCModel : PageModel
    {
        //Definimos los atributos 
        [BindProperty]
        public string peso { get; set; }
        [BindProperty]
        public string altura { get; set; }
        public double? imc { get; set; } = null;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //Recibimos el peso y la altura
            double p = Convert.ToDouble(peso);
            double a = Convert.ToDouble(altura);

            imc = p / (a*a);

            ModelState.Clear();

        }
    }
}
