using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
        
        
    public class EditMecanicoModel : PageModel
    {
        public Mecanico mecanicoActual;
        private static RepositorioMecanico repositorio = new RepositorioMecanico(
            new Persistencia.ContextDb()
        );
        public void OnGet(string id)
        {
            if(id !=null)
            {
                this.mecanicoActual = repositorio.BuscarMecanico(id);
            }
        }

        public IActionResult OnPostEdit(Mecanico mecanico)
        {
            repositorio.ActualizarMecanico(mecanico);
            return RedirectToPage("/Operaciones/Mecanicos", new {id = mecanico.Id});
        }
    }
}
