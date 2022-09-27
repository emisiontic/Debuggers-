using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class UsuariosModel : PageModel
    {

        private static RepositorioDueno repositorio = new RepositorioDueno(
            new Persistencia.ContextDb()
        );  

        public IEnumerable<Dueno> duenos;

        public void OnGet(string id)
        {

            if(id != null)
            {
                ObtenerDuenos(id);
            }else{

                ObtenerDuenos();
            }
        }

        private void ObtenerDuenos()
        {
            this.duenos = (IEnumerable<Dueno>)repositorio.ObtenerDuenos();
            // foreach (var mecanico in repositorio.ObtenerMecanicos())
            // {
            //     this.mecanicos.Add(
            //         new Mecanico()
            //         {
            //             Id = mecanico.Id,
            //             Nombre = mecanico.Nombre,
            //             Direccion = mecanico.Direccion,
            //             Telefono = mecanico.Telefono,
            //             FechaNacimiento = mecanico.FechaNacimiento
            //         }
            //     );
            // }
        }

        private void ObtenerDuenos(string id)
        {
            this.duenos = (IEnumerable<Dueno>)repositorio.ObtenerDuenos(id);
        }

        public void OnPostDelete(string id)
        {
            repositorio.EliminarDueno(id);
            this.ObtenerDuenos();
        }

        public void OnPostAdd(Dueno dueno)
        {
            repositorio.AgregarDueno(dueno);
            this.ObtenerDuenos();
        }
    }
}
