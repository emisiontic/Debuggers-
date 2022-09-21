using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;

namespace Taller.App.Persistencia
{
    public class RepositorioDueno
    {

        private readonly ContextDb contextDb;

        public RepositorioDueno(ContextDb contextDb)
        {
            this.contextDb = contextDb;
        }

        public bool AgregarDueno(Dueno dueno)
        {
            var duenoVer = this.contextDb.Duenos.FirstOrDefault(m => m.Id == dueno.Id);
            if (duenoVer != null)
            {
                return false;
            }
            else
            {
                var duenoNuevo = this.contextDb.Duenos.Add(dueno);
                this.contextDb.SaveChanges();
                return true;
            }


        }

        public IEnumerable<Dueno> ObtenerDuenos()
        {
            return this.contextDb.Duenos;
        }

        public Dueno BuscarDueno(string id)
        {
            return this.contextDb.Duenos.FirstOrDefault(m => m.Id == id);
        }

        public bool EliminarDueno(string id)
        {
            var dueno = this.contextDb.Duenos.FirstOrDefault(m => m.Id == id);
            if (dueno != null)
            {

                this.contextDb.Duenos.Remove(dueno);
                this.contextDb.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ActualizarDueno(Dueno duenoNuevo)
        {
            var duenoActual = this.contextDb.Duenos.FirstOrDefault(m => m.Id == duenoNuevo.Id);
            if (duenoActual != null)
            {

                duenoActual.Nombre = duenoNuevo.Nombre;
                duenoActual.Telefono = duenoNuevo.Telefono;
                duenoActual.FechaNacimiento = duenoNuevo.FechaNacimiento;
                duenoActual.Contrasenia = duenoNuevo.Contrasenia;
                duenoActual.Ciudad = duenoNuevo.Ciudad;
                duenoActual.Correo = duenoNuevo.Correo;

                this.contextDb.SaveChanges();

            }

        }
    }
}