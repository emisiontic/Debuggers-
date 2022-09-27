using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class AddRevisionModel : PageModel
    {

        private static RepositorioVehiculo repositorio = new RepositorioVehiculo(
            new Persistencia.ContextDb()
        );

        private static RepositorioRevision repositorioR = new RepositorioRevision(
            new Persistencia.ContextDb()
        );
        public IEnumerable<Vehiculo> vehiculos;
        public IEnumerable<Revision> revisiones;
        public void OnGet()
        {
            ObtenerVehiculos();
        }

        public IActionResult OnPostAdd(Revision revision)
        {
            repositorioR.AgregarRevision(revision);
            // return RedirectToPage("/Operaciones/OpVehiculos", new {tipo = vehiculo.Tipo});
            return new RedirectToPageResult("/Usuarios/Revisiones");
        }

        private void ObtenerVehiculos()
        {
            this.vehiculos = (IEnumerable<Vehiculo>)repositorio.ObtenerVehiculos();
        }
    }
}
