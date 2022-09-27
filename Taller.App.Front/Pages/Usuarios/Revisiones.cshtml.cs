using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class RevisionesModel : PageModel
    {
        public IEnumerable<Revision> revisiones;
        private static RepositorioRevision repositorio = new RepositorioRevision(
            new Persistencia.ContextDb()
            );
        public void OnGet()
        {
            //   if(id != null)
            // {
            //    ObtenerRevisiones(id);
            // }else{

            // ObtenerRevisiones();
            // }

            ObtenerRevisiones();
        }

        private void ObtenerRevisiones()
        {
            this.revisiones = (IEnumerable<Revision>)repositorio.ObtenerRevisiones();
        }

        // private void ObtenerRevisiones(int id)
        // {
        //     this.revisiones = (IEnumerable<Revision>)repositorio.ObtenerRevisiones(id);
        // }

        public void OnPostDelete(int id)
        {
            repositorio.EliminarRevision(id);
            this.ObtenerRevisiones();
        }
    }
}
