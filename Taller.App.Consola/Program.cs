using System;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Consola
{
    class Program
    {
        private static RepositorioMecanico repositorio = new RepositorioMecanico(
            new Persistencia.ContextDb()
        );

        private static RepositorioDueno repositorioD = new RepositorioDueno(
            new Persistencia.ContextDb()
        );

        private static RepositorioVehiculo repositorioV = new RepositorioVehiculo(
            new Persistencia.ContextDb()
        );

        static void Main(string[] args)
        {
            // AgregarMecanico();
            // ObtenerMecanicos();
            // BuscarMecanico("4");
            // EliminarMecanico("1");
            // EditarMecanico();

            // AgregarDueno();
            ObtenerDuenos();
            // BuscarDueno("5");
            // EliminarDueno("1");
            // EditarDueno();

            // AgregarVehiculo();
            // ObtenerVehiculos();
            // BuscarVehiculo("3");
            // EliminarVehiculo("2");
            // EditarVehiculo();

        }

        static void AgregarMecanico()
        {
            var mecanicoNuevo = new Mecanico
            {
                Id = "1",
                Nombre = "Pedro",
                Telefono = "3207199861",
                FechaNacimiento = "19/08/1984",
                Contrasenia = "12345",
                Direccion = "carrera 13 # 4-31",
                NivelEstudio = "Tecnologo"
            };
            var info = repositorio.AgregarMecanico(mecanicoNuevo);

            if (info)
            {

                Console.WriteLine("Mecánico creado satisfactoriamente");

            }
            else
            {

                Console.WriteLine("Mecánico ya registrado");

            }
        }

        static void ObtenerMecanicos()
        {
            foreach (var mecanico in repositorio.ObtenerMecanicos())
            {
                Console.WriteLine("Nombre: " + mecanico.Nombre + " " + "Id: " + mecanico.Id);


            }
        }

        static void BuscarMecanico(string id)
        {
            var mecanico = repositorio.BuscarMecanico(id);
            if (mecanico != null)
            {
                Console.WriteLine("Se encontro el mecanico:" + mecanico.Nombre);
            }
            else
            {
                Console.WriteLine("NO SE ENCONTRO");
            }
        }

        static void EliminarMecanico(string id)
        {
            var mecanico = repositorio.EliminarMecanico(id);
            if (mecanico)
            {
                Console.WriteLine("Mecanico Eliminado");
            }
        }

        static void EditarMecanico()
        {
            var mecanicoNuevo = new Mecanico
            {
                Id = "4",
                Nombre = "Pedro",
                Telefono = "3206529602",
                FechaNacimiento = "19/08/1984",
                Contrasenia = "12345",
                Direccion = "carrera 13 # 4-31",
                NivelEstudio = "Tecnologo"
            };
            repositorio.ActualizarMecanico(mecanicoNuevo);
            Console.WriteLine("Mecánico actualizado");
        }

        // DUEÑOS DE VEHICULOS

        static void AgregarDueno()
        {
            var duenoNuevo = new Dueno
            {
                Id = "3",
                Nombre = "Alejandro",
                Telefono = "3207199861",
                FechaNacimiento = "19/08/1984",
                Contrasenia = "12345",
                Ciudad = "Caicedonia",
                Correo = "aserna37@hotmail.com"
            };
            var info = repositorioD.AgregarDueno(duenoNuevo);
            if (info)
            {

                Console.WriteLine("Dueño creado satisfactoriamente");

            }
            else
            {

                Console.WriteLine("Dueño ya registrado");

            }
        }

        static void ObtenerDuenos()
        {
            foreach (var dueno in repositorioD.ObtenerDuenos())
            {
                Console.WriteLine("Id: " + dueno.Id + " " + "Nombre: " + dueno.Nombre);
            }
        }

        static void BuscarDueno(string id)
        {
            var dueno = repositorioD.BuscarDueno(id);
            if (dueno != null)
            {
                Console.WriteLine("Se encontro el dueno:" + dueno.Nombre);
            }
            else
            {
                Console.WriteLine("NO SE ENCONTRO");
            }
        }

        static void EliminarDueno(string id)
        {
            // var provehiculo = repositorioV.BuscarVehiculoPropietario(id);

            // if (provehiculo != null)
            // {
            //     Console.WriteLine("No se puede eliminar ya que tiene vehiculos relacionados");
            // }
            // else
            // {
                var dueno = repositorioD.EliminarDueno(id);
                if (dueno)
                {
                    Console.WriteLine("Dueño Eliminado");
                }

            // }


        }

        static void EditarDueno()
        {
            var duenoNuevo = new Dueno
            {
                Id = "4",
                Nombre = "Pedro",
                Telefono = "3206529602",
                FechaNacimiento = "19/08/1984",
                Contrasenia = "12345",
                Ciudad = "Cali",
                Correo = "asernacalle@gmail.com"
            };
            repositorioD.ActualizarDueno(duenoNuevo);
            Console.WriteLine("Dueño actualizado");
        }


        // VEHICULOS

        static void AgregarVehiculo()
        {
            var vehiculoNuevo = new Vehiculo
            {
                Id = "2",
                Tipo = "Buseta",
                Marca = "Mazda",
                Modelo = "1985",
                Capacidad_pasajeros = "10",
                Cilindraje = "3000",
                Pais_origen = "Canada",
                Carateristicas = "Aire acondicionado",
                DuenoId = "4"
            };

            var varDueno = repositorioD.BuscarDueno(vehiculoNuevo.DuenoId);

            if (varDueno != null)
            {

                var info = repositorioV.AgregarVehiculo(vehiculoNuevo);

                if (info)
                {

                    Console.WriteLine("Vehiculo creado satisfactoriamente");

                }
                else
                {

                    Console.WriteLine("Vehiculo ya registrado");

                }

            }
            else
            {

                Console.WriteLine("Dueño no registrado");
            }


        }

        static void ObtenerVehiculos()
        {
            foreach (var vehiculo in repositorioV.ObtenerVehiculos())
            {
                Console.WriteLine("Placa: " + vehiculo.Id + " " + "Tipo: " + vehiculo.Tipo);
            }
        }

        static void BuscarVehiculo(string id)
        {
            var placa = repositorioV.BuscarVehiculo(id);
            if (placa != null)
            {
                Console.WriteLine("Se encontro la placa:" + placa.Id);
            }
            else
            {
                Console.WriteLine("NO SE ENCONTRO PLACA");
            }
        }

        static void EliminarVehiculo(string id)
        {
            var vehiculo = repositorioV.EliminarVehiculo(id);
            if (vehiculo)
            {
                Console.WriteLine("Vehiculo Eliminado");
            }
        }

        static void EditarVehiculo()
        {
            var vehiculoNuevo = new Vehiculo
            {
                Id = "1",
                Tipo = "Buseta",
                Marca = "Mazda",
                Modelo = "2022",
                Capacidad_pasajeros = "12",
                Cilindraje = "3000",
                Pais_origen = "Canada",
                Carateristicas = "Aire acondicionado",
                DuenoId = "4"
            };
            repositorioV.ActualizarVehiculo(vehiculoNuevo);
            Console.WriteLine("Vehiculo Actualizado");
        }







    }
}
