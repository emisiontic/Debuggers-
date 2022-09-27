using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio
{
    public class Revision
    {
        public int Id {get;set;}
        public string Placa {get;set;}
        public string Fecha{get;set;}
        public string Hora{get;set;}
        public string Servicio{get;set;}
        public string Sede{get;set;}
        public string Estado{get;set;}
        public string MecanicoId{get;set;}

    }
}