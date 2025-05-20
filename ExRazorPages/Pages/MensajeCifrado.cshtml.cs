using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExRazorPages.Pages
{
    public class MensajeCifradoModel : PageModel
    {
        private const string abcdario = "ABCDEFGHIJKLMNÑOPQRSTUVXYZ";

        [BindProperty]
        public string texto { get; set; }

        [BindProperty]
        public int desplazamiento { get; set; } = 3;

        public string resultado { get; set; }

        public void OnGet() { }

        public void OnPost(string accion)
        {
            switch (accion)
            {
                case "Codificar":
                    resultado = ProcesarTexto(texto, desplazamiento);
                    break;
                case "Decodificar":
                    resultado = ProcesarTexto(texto, -desplazamiento);
                    break;
            }
        }

        private string ProcesarTexto(string texto, int desplazamiento)
        {
            desplazamiento = desplazamiento % abcdario.Length;
            if (desplazamiento < 0) desplazamiento += abcdario.Length;

            var resultado = new StringBuilder();

            foreach (char c in texto.ToUpper())
            {
                int indice = abcdario.IndexOf(c);
                if (indice >= 0)
                {
                    int nuevoIndice = (indice + desplazamiento) % abcdario.Length;
                    resultado.Append(abcdario[nuevoIndice]);
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }

    }
}
