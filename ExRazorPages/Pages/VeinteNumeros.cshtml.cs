using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExRazorPages.Pages
{
    public class VeinteNumerosModel : PageModel
    {

        [BindProperty]
        public int[] numeros { get; set; }
        public int[] copiaOrdenada { get; set; }
        
        [BindProperty]
        public int sumaT { get; set; }
        [BindProperty]
        public double prom { get; set; }
        [BindProperty]
        public int modaR { get; set; }
        [BindProperty]
        public double mediana { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Random random = new Random();
            numeros = new int[20];
            int suma = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = random.Next(0, 101);
                suma += numeros[i];
            }

            sumaT = suma;
            prom = (double)suma / 20;

            int moda = numeros[0];
            int totalRep = 0;
            int n = 0;
            do
            {
                int numeroActual = numeros[n];
                int repeticiones = 0;
                int j = 0;

                do
                {
                    if (numeros[j] == numeroActual)
                    {
                        repeticiones++;
                    }
                    j++;
                } while (j < numeros.Length);

                if (repeticiones > totalRep)
                {
                    totalRep = repeticiones;
                    moda = numeroActual;
                }

                n++;
            } while (n < numeros.Length);

            modaR = moda;

            int[] copiaOrdenada = (int[])numeros.Clone();
            Array.Sort(copiaOrdenada);

            if (copiaOrdenada.Length % 2 == 0)
            {
                int medio1 = copiaOrdenada[copiaOrdenada.Length / 2 - 1];
                int medio2 = copiaOrdenada[copiaOrdenada.Length / 2];
                mediana = (medio1 + medio2) / 2.0;
            }
            else
            {
                mediana = copiaOrdenada[copiaOrdenada.Length / 2];
            }

        }

        
    }
}
