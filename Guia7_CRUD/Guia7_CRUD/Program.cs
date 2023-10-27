using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Guia7_CRUD;

class Program
{
    static void Main()
    {
        while (true)
        {
            using (var context = new Context())
            {
                Console.WriteLine("Lista de Estudiantes:");
                foreach (var estudiante in context.Estudiante.ToList())
                {
                    Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}, Edad: {estudiante.Edad}, Sexo: {estudiante.Sexo}\n");
                }
            }

            using (var context = new Context())
            {
                Console.WriteLine("Ingresar el Id que desea modificar ");

                var id = Console.ReadLine();
                var persona = context.Estudiante.FirstOrDefault(p => p.Id == Int32.Parse(id));
                if (persona != null)
                {
                    persona.Apellido = "Atributo modificado";
                    context.SaveChanges();
                    if (persona != null)
                    {
                        Console.WriteLine("¿Qué atributo desea modificar? (Nombre, Apellido, Sexo, Edad)");
                        var eleccion = Console.ReadLine().ToLower().Trim();

                        switch (eleccion)
                        {
                            case "nombre":
                                Console.WriteLine("Ingresar el nuevo nombre:");
                                persona.Nombre = Console.ReadLine();
                                break;
                            case "apellido":
                                Console.WriteLine("Ingresar el nuevo apellido:");
                                persona.Apellido = Console.ReadLine();
                                break;
                            case "sexo":
                                Console.WriteLine("Ingresar el nuevo sexo:");
                                persona.Sexo = Console.ReadLine();
                                break;
                            case "edad":
                                Console.WriteLine("Ingresar la nueva edad:");
                                persona.Edad = int.Parse(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("El atributo ingresado no es válido");
                                return;
                        }

                        context.SaveChanges();
                        Console.WriteLine("El registro se ha modificado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("El Id ingresado es inválido");
                    }
                }
            }

            using (var context = new Context())
            {
                Console.WriteLine("\nIngresar el Id del registro que desea eliminar");
                var Id = Console.ReadLine();
                var persona = context.Estudiante.SingleOrDefault(p => p.Id == Int32.Parse(Id));
                if (persona != null)
                {
                    context.Estudiante.Remove(persona);
                    context.SaveChanges();
                }

                //Console.WriteLine("\nIngrese los datos de los nuevos estudiantes:");

                //Console.Write("Nombre: ");
                //var nombre = Console.ReadLine();

                //Console.Write("Apellido: ");
                //var apellido = Console.ReadLine();

                //Console.Write("Sexo: ");
                //var sexo = Console.ReadLine();

                //Console.Write("Edad: ");
                //if (int.TryParse(Console.ReadLine(), out int edad))
                //{
                //    var nuevoEstudiante = new EstudianteUNAB
                //    {
                //        Nombre = nombre,
                //        Apellido = apellido,
                //        Sexo = sexo,
                //        Edad = edad
                //    };

                //    using (var context = new Context())
                //    {
                //        try
                //        {
                //            context.Estudiante.Add(nuevoEstudiante);
                //            context.SaveChanges();
                //            Console.WriteLine("Estudiante agregado correctamente.");
                //        }
                //        catch (DbUpdateException ex)
                //        {
                //            Console.WriteLine("Error al agregar estudiante. Asegúrate de que los datos sean válidos.");
                //        }
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Edad no válida. Intente nuevamente.");
                //}

                Console.Write("¿Si de sea agregar mas estudiante presione (S) y si ya no de sea ingresar presione (N): ");
                var respuesta = Console.ReadLine();
                if (respuesta?.Trim().ToLower() != "s")
                {
                    break;
                }
            }
        }
    }
}