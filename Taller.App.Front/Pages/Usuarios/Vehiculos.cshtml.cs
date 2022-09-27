using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class VehiculosModel : PageModel
    {
        public IEnumerable<Vehiculo> vehiculos;
        private static RepositorioVehiculo repositorio = new RepositorioVehiculo(
            new Persistencia.ContextDb()
        );
        public void OnGet(string id)
        {
            if(id != null)
            {
                ObtenerVehiculos(id);
            }else{

            ObtenerVehiculos();
            }
        }

        private void ObtenerVehiculos()
        {
            this.vehiculos = (IEnumerable<Vehiculo>)repositorio.ObtenerVehiculos();
        }

        private void ObtenerVehiculos(string id)
        {
            this.vehiculos = (IEnumerable<Vehiculo>)repositorio.ObtenerVehiculos(id);
        }

        public void OnPostDelete(string id)
        {
            repositorio.EliminarVehiculo(id);
            this.ObtenerVehiculos();
        }

    }
}
