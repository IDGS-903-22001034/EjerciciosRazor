using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ExRazorPages.Pages
{
    public class IgualdadModel : PageModel
    {
        //Definimos los atributos 
        [BindProperty]
        public string aUno { get; set; }
        [BindProperty]
        public string bUno { get; set; }
        [BindProperty]
        public string yUno { get; set; }
        [BindProperty]
        public string xUno { get; set; }
        [BindProperty]
        public string nUno { get; set; }
        [BindProperty]
        public int resultadoUno { get; set; }
        [BindProperty]
        public int resultadoDos { get; set; }
        [BindProperty]
        public  int k {  get; set; }
        [BindProperty]
        public List<string> Terminos { get; set; } = new List<string>();
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //Recibimos el peso y la altura
            int a = Convert.ToInt32(aUno);
            int b = Convert.ToInt32(bUno);
            int y = Convert.ToInt32(yUno);
            int x = Convert.ToInt32(xUno);
            int n = Convert.ToInt32(nUno);

            resultadoUno = (int)Math.Pow((a * x) + (b * y),n);



            // Cálculo mediante expansión binomial
            resultadoDos = 0;
            Terminos.Clear();

            for (int k = 0; k <= n; k++)
            {
                int coef = CoeficienteBinomial(n, k);
                int termino = coef * (int)Math.Pow(a * x, n - k) * (int)Math.Pow(b * y, k);

                Terminos.Add($"Término k{k} = {termino}");
                resultadoDos += termino;
            }
        }

        private int CoeficienteBinomial(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private int Factorial(int num)
        {
            if (num <= 1) return 1;
            return num * Factorial(num - 1);
        }

    }

    
}
