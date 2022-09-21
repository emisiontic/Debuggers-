using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;

namespace Taller.App.Persistencia
{
    public class RepositorioMecanico
    {
        private readonly ContextDb contextDb;

        public RepositorioMecanico(ContextDb contextDb)
        {
            this.contextDb = contextDb;
        }

        public bool AgregarMecanico(Mecanico mecanico)
        {
            var mecanicoVer = this.contextDb.Mecanicos.FirstOrDefault(m => m.Id == mecanico.Id);
             if(mecanicoVer != null){
                return false;
             }else{
            var mecanicoNuevo = this.contextDb.Mecanicos.Add(mecanico);
            this.contextDb.SaveChanges();
            return true;

             }
        }

        

        public IEnumerable<Mecanico> ObtenerMecanicos()
        {
            return this.contextDb.Mecanicos; 
        }

        public Mecanico BuscarMecanico(string id)
        {
            return this.contextDb.Mecanicos.FirstOrDefault(m => m.Id == id);
        }

        public bool EliminarMecanico(string id)
        {
          var mecanico = this.contextDb.Mecanicos.FirstOrDefault(m => m.Id == id);  
            if(mecanico != null){
                this.contextDb.Mecanicos.Remove(mecanico);
                this.contextDb.SaveChanges();
                return true;
            }else{
                return false;
            }
        }

        public void ActualizarMecanico(Mecanico mecanicoNuevo)
        {
            var mecanicoActual = this.contextDb.Mecanicos.FirstOrDefault(m => m.Id == mecanicoNuevo.Id);
            if(mecanicoActual != null){

                mecanicoActual.Nombre = mecanicoNuevo.Nombre;
                mecanicoActual.Telefono = mecanicoNuevo.Telefono;
                mecanicoActual.FechaNacimiento = mecanicoNuevo.FechaNacimiento;
                mecanicoActual.Contrasenia = mecanicoNuevo.Contrasenia;
                mecanicoActual.Direccion = mecanicoNuevo.Direccion;
                mecanicoActual.NivelEstudio = mecanicoNuevo.NivelEstudio;
                 
                this.contextDb.SaveChanges();
                
            }
            
        }



        
    }
}   
