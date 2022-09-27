using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class EditUsuarioModel : PageModel
    {
        public Dueno duenoActual;
        private static RepositorioDueno repositorio = new RepositorioDueno(
            new Persistencia.ContextDb()
        );
        public void OnGet(string id)
        {
            if(id !=null)
            {
                this.duenoActual = repositorio.BuscarDueno(id);
            }
        }

        public IActionResult OnPostEdit(Dueno dueno)
        {
            repositorio.ActualizarDueno(dueno);
            return RedirectToPage("/Operaciones/Usuarios", new {id = dueno.Id});
        }
    }
}
