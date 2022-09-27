using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;

namespace Taller.App.Persistencia
{
    public class RepositorioVehiculo
    {

        private readonly ContextDb contextDb;

        public RepositorioVehiculo(ContextDb contextDb)
        {
            this.contextDb = contextDb;
        }

        public bool AgregarVehiculo(Vehiculo vehiculo)
        {
            var vehiculoVer = this.contextDb.Vehiculos.FirstOrDefault(m => m.Id == vehiculo.Id);
            if (vehiculoVer != null)
            {
                return false;
            }
            else
            {
                var vehiculoNuevo = this.contextDb.Vehiculos.Add(vehiculo);
                this.contextDb.SaveChanges();
                return true;
            }


        }


        public IEnumerable<Vehiculo> ObtenerVehiculos()
        {
            return this.contextDb.Vehiculos;
        }

        public IEnumerable<Vehiculo> ObtenerVehiculos(string id)
        {
            var vehiculo = BuscarVehiculo(id);
            this.contextDb.Entry(vehiculo).Reload();
            return this.contextDb.Vehiculos; 
        }

        public Vehiculo BuscarVehiculo(string id)
        {
            return this.contextDb.Vehiculos.FirstOrDefault(m => m.Id == id);
        }

        public bool EliminarVehiculo(string id)
        {
            var vehiculo = this.contextDb.Vehiculos.FirstOrDefault(m => m.Id == id);
            if (vehiculo != null)
            {
                this.contextDb.Vehiculos.Remove(vehiculo);
                this.contextDb.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ActualizarVehiculo(Vehiculo vehiculoNuevo)
        {
            var vehiculoActual = this.contextDb.Vehiculos.FirstOrDefault(m => m.Id == vehiculoNuevo.Id);
            if (vehiculoActual != null)
            {

                vehiculoActual.Tipo = vehiculoNuevo.Tipo;
                vehiculoActual.Marca = vehiculoNuevo.Marca;
                vehiculoActual.Modelo = vehiculoNuevo.Modelo;
                vehiculoActual.Capacidad_pasajeros = vehiculoNuevo.Capacidad_pasajeros;
                vehiculoActual.Cilindraje = vehiculoNuevo.Cilindraje;
                vehiculoActual.Pais_origen = vehiculoNuevo.Pais_origen;
                vehiculoActual.Carateristicas = vehiculoNuevo.Carateristicas;
                vehiculoActual.DuenoId = vehiculoNuevo.DuenoId;

                this.contextDb.SaveChanges();

            }

        }

        // public IEnumerable<Vehiculo> BuscarVehiculoPropietario(string id)
        // {
        //     return this.contextDb.Vehiculos.Where(m => m.DuenoId == id);
        // }


    }
}