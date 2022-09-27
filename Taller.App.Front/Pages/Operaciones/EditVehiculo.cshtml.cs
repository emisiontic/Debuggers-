using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class EditVehiculoModel : PageModel
    {
        public Vehiculo vehiculoActual;
        private static RepositorioVehiculo repositorio = new RepositorioVehiculo(
            new Persistencia.ContextDb()
        );
        public void OnGet(string id)
        {
            if(id !=null)
            {
                this.vehiculoActual = repositorio.BuscarVehiculo(id);
            }
        }

        public IActionResult OnPostEdit(Vehiculo vehiculo)
        {
            repositorio.ActualizarVehiculo(vehiculo);
            return RedirectToPage("/Operaciones/OpVehiculos", new {id = vehiculo.Id});
        }
    }
}
