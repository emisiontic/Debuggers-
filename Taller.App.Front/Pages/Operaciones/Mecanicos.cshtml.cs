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
        public IEnumerable<Mecanico> mecanicos;

        public bool addIsOpen{get; set;} = false;
        public void OnGet(string id)
        {
            if(id != null)
            {
                ObtenerMecanicos(id);
            }else{

            ObtenerMecanicos();
            }
        }

        public void OnPostAdd(Mecanico mecanico)
        {
            repositorio.AgregarMecanico(mecanico);
            this.ObtenerMecanicos();
        }

        public void OnPostDelete(string id)
        {
            repositorio.EliminarMecanico(id);
            this.ObtenerMecanicos();
        }

        private void ObtenerMecanicos()
        {
            this.mecanicos = (IEnumerable<Mecanico>)repositorio.ObtenerMecanicos();
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

        private void ObtenerMecanicos(string id)
        {
            this.mecanicos = (IEnumerable<Mecanico>)repositorio.ObtenerMecanicos(id);
        }
    }
}
