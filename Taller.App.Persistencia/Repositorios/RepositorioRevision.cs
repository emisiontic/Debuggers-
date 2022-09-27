using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;

namespace Taller.App.Persistencia
{
    public class RepositorioRevision
    {
        private readonly ContextDb contextDb;

        public RepositorioRevision(ContextDb contextDb)
        {
            this.contextDb = contextDb;
        }

        public bool AgregarRevision(Revision revision)
        {
            var revisionVer = this.contextDb.Revisiones.FirstOrDefault(m => m.Id == revision.Id);
             if(revisionVer != null){
                return false;
             }else{
            var revisionNueva = this.contextDb.Revisiones.Add(revision);
            this.contextDb.SaveChanges();
            return true;

             }
        }

        public IEnumerable<Revision> ObtenerRevisiones()
        {
            return this.contextDb.Revisiones; 
        }

        // public IEnumerable<Revision> ObtenerRevisiones(int id)
        // {
        //     var revision = BuscarRevision(id);
        //     this.contextDb.Entry(revision).Reload();
        //     return this.contextDb.Revisiones; 
        // }

        public Revision BuscarRevision(int id)
        {
            return this.contextDb.Revisiones.FirstOrDefault(m => m.Id == id);
        }

        public bool EliminarRevision(int id)
        {
          var revision = this.contextDb.Revisiones.FirstOrDefault(m => m.Id == id);  
            if(revision != null){
                this.contextDb.Revisiones.Remove(revision);
                this.contextDb.SaveChanges();
                return true;
            }else{
                return false;
            }
        }

        public void ActualizarRevision(Revision revisionNueva)
        {
            var revisionActual = this.contextDb.Revisiones.FirstOrDefault(m => m.Id == revisionNueva.Id);
            if(revisionActual != null){

                revisionActual.Placa =      revisionNueva.Placa;
                revisionActual.Fecha =      revisionNueva.Fecha;
                revisionActual.Hora =       revisionNueva.Hora;
                revisionActual.Servicio =   revisionNueva.Servicio;
                revisionActual.Sede =       revisionNueva.Sede;
                revisionActual.Estado =     revisionNueva.Estado;
                revisionActual.MecanicoId = revisionNueva.MecanicoId;
                 
                this.contextDb.SaveChanges();
                
            }
            
        }
        
    }
}