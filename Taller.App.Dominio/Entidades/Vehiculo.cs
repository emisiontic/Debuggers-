using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio
{
    public class Vehiculo
    {
        
        public string Id {get; set;}
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Capacidad_pasajeros { get; set; }
        public string Cilindraje { get; set; }
        public string Pais_origen { get; set; }
        public string Carateristicas { get; set; }
        public string DuenoId {get; set;}
    }
}