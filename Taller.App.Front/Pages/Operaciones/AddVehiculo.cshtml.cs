using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class AddVehiculoModel : PageModel
    {
        private static RepositorioVehiculo repositorio = new RepositorioVehiculo(
            new Persistencia.ContextDb()
        );

        private static RepositorioDueno repositorioD = new RepositorioDueno(
            new Persistencia.ContextDb()
        );

        public IEnumerable<Vehiculo> vehiculos;
        public IEnumerable<Dueno> duenos;
        public void OnGet()
        {

            ObtenerDuenos();
        }

        public IActionResult OnPostAdd(Vehiculo vehiculo)
        {
            repositorio.AgregarVehiculo(vehiculo);
            // return RedirectToPage("/Operaciones/OpVehiculos", new {tipo = vehiculo.Tipo});
            return new RedirectToPageResult("/Operaciones/OpVehiculos");
        }

        private void ObtenerDuenos()
        {
            this.duenos = (IEnumerable<Dueno>)repositorioD.ObtenerDuenos();
        }
    }
}
