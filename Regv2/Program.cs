using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistroPersonas
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidad = LeerEntero("Ingrese el número de personas a registrar: ", minimo: 1);
            var personas = RegistrarPersonas(cantidad);
            MostrarResultados(personas);
            Console.ReadKey();
        }


        static int LeerEntero(string mensaje, int minimo = 0)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine() ?? "", out int valor) && valor >= minimo)
                    return valor;

                Console.WriteLine("Error: valor inválido, por favor intente nuevamente.");
            }
        }

        static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada;

                Console.WriteLine("Error: el campo no puede estar vacío, por favor intente nuevamente.");
            }
        }


        static List<(string Nombre, int Edad)> RegistrarPersonas(int cantidad)
        {
            var lista = new List<(string Nombre, int Edad)>();

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nPersona {i + 1}");
                string nombre = LeerTexto("Nombre: ");
                int edad = LeerEntero("Edad: ");
                lista.Add((nombre, edad));
            }

            return lista;
        }


        static void MostrarResultados(List<(string Nombre, int Edad)> personas)
        {
            if (personas.Count == 1)
            {
                var p = personas[0];
                string condicion = p.Edad >= 18 ? "mayor" : "menor";
                Console.WriteLine($"\nResultado:\n{p.Nombre} tiene {p.Edad} años y es {condicion} de edad.");
                return;
            }

            Console.WriteLine("\nLista general:");
            foreach (var p in personas)
                Console.WriteLine($"{p.Nombre} - {p.Edad} años");

            MostrarGrupo("Mayores de edad:", personas.Where(p => p.Edad >= 18));
            MostrarGrupo("Menores de edad:", personas.Where(p => p.Edad < 18));
        }

        static void MostrarGrupo(string titulo, IEnumerable<(string Nombre, int Edad)> grupo)
        {
            var lista = grupo.ToList();
            if (lista.Count == 0) return;

            Console.WriteLine($"\n{titulo}");
            foreach (var p in lista)
                Console.WriteLine($"{p.Nombre} - {p.Edad} años");
        }
    }
}