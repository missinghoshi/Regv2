using System;
using System.Collections.Generic;

namespace RegistroPersonas
{
    class Program
    {
        
        static (string Nombre, int Edad) LeerPersona(int numero)
        {
            Console.WriteLine($"\nPersona {numero}");

            string nombre;
            while (true)
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(nombre))
                    break;
                Console.WriteLine("Error: El nombre no puede estar vacío, por favor intente nuevamente.");
            }

            int edad;
            while (true)
            {
                Console.Write("Edad: ");
                if (int.TryParse(Console.ReadLine() ?? "", out edad) && edad >= 0)
                    break;
                Console.WriteLine("Error: Edad inválida, por favor intente nuevamente.");
            }

            return (nombre, edad);
        }

        
        static (List<(string Nombre, int Edad)> Mayores, List<(string Nombre, int Edad)> Menores)
            ClasificarPersonas(List<(string Nombre, int Edad)> lista)
        {
            var mayores = new List<(string Nombre, int Edad)>();
            var menores = new List<(string Nombre, int Edad)>();

            foreach (var persona in lista)
            {
                if (persona.Edad >= 18)
                    mayores.Add(persona);
                else
                    menores.Add(persona);
            }

            return (mayores, menores);
        }

        
        static void MostrarResultados(List<(string Nombre, int Edad)> lista)
        {
            if (lista.Count == 1)
            {
                var persona = lista[0];
                string condicion = persona.Edad >= 18 ? "mayor" : "menor";
                Console.WriteLine("\nResultado:");
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años y es {condicion} de edad.");
            }
            else
            {
                Console.WriteLine("\nLista general:");
                foreach (var persona in lista)
                    Console.WriteLine($"{persona.Nombre} - {persona.Edad} años");

                var (mayores, menores) = ClasificarPersonas(lista);

                if (mayores.Count > 0)
                {
                    Console.WriteLine("\nMayores de edad:");
                    foreach (var p in mayores)
                        Console.WriteLine($"{p.Nombre} - {p.Edad} años");
                }

                if (menores.Count > 0)
                {
                    Console.WriteLine("\nMenores de edad:");
                    foreach (var p in menores)
                        Console.WriteLine($"{p.Nombre} - {p.Edad} años");
                }
            }
        }

        
        static void Main(string[] args)
        {
            int cantidadPersonas = 0;
            while (true)
            {
                Console.Write("Ingrese el número de personas a registrar: ");
                if (int.TryParse(Console.ReadLine() ?? "", out cantidadPersonas) && cantidadPersonas >= 1)
                    break;
                Console.WriteLine("Error: Cantidad inválida, por favor intente nuevamente.");
            }

            var listaPersonas = new List<(string Nombre, int Edad)>();

            for (int i = 0; i < cantidadPersonas; i++)
            {
                var persona = LeerPersona(i + 1);   
                listaPersonas.Add(persona);
            }

            MostrarResultados(listaPersonas);        
            Console.ReadKey();
        }
    }
}