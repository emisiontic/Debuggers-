using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class MecanicosModel : PageModel
    {

        private static RepositorioMecanico repositorio = new RepositorioMecanico(
            new Persistencia.ContextDb()
        );
        public List<Mecanico> mecanicos = new List<Mecanico>();
        public void OnGet()
        {
            ObtenerMecanicos();
        }
        private void ObtenerMecanicos()
        {
            foreach (var mecanico in repositorio.ObtenerMecanicos())
            {
                this.mecanicos.Add(
                    new Mecanico()
                    {
                        Id = mecanico.Id,
                        Nombre = mecanico.Nombre,
                        Direccion = mecanico.Direccion,
                        Telefono = mecanico.Telefono,
                        FechaNacimiento = mecanico.FechaNacimiento
                    }
                );
            }
        }
    }
}
