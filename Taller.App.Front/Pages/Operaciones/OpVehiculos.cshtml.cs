using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class OpVehiculosModel : PageModel
    {
        private static RepositorioVehiculo repositorio = new RepositorioVehiculo(
            new Persistencia.ContextDb()
        );
        public List<Vehiculo> vehiculos = new List<Vehiculo>();
        public void OnGet()
        {
            ObtenerVehiculos();
        }

        private void ObtenerVehiculos()
        {
            foreach (var vehiculo in repositorio.ObtenerVehiculos())
            {
                this.vehiculos.Add(
                    new Vehiculo()
                    {
                        Id =        vehiculo.Id,
                        Tipo =      vehiculo.Tipo,
                        Marca =     vehiculo.Marca,
                        Modelo =    vehiculo.Modelo,
                        Capacidad_pasajeros = vehiculo.Capacidad_pasajeros
                    }
                );
            }
        }
    }
}
