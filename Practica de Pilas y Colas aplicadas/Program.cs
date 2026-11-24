using System;
using System.Collections.Generic;

namespace PracticaPilasYColas
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("   PRÁCTICA: PILAS (STACKS) Y COLAS (QUEUES)");
                Console.WriteLine("1. Parte I  - Navegador Web (Pila / Stack)");
                Console.WriteLine("2. Parte II - Atención en Banco (Cola / Queue)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1:
                        MenuNavegadorWeb();
                        break;
                    case 2:
                        MenuBanco();
                        break;
                    case 0:
                        Console.WriteLine("Cerrando el programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 0);
        }

        // PILAS (STACKS): HISTORIAL DE NAVEGADOR WEB
        // Principio LIFO (Last In, First Out)

        static void MenuNavegadorWeb()
        {
            // Se utiliza Stack<string> para almacenar las URLs visitadas
            Stack<string> historial = new Stack<string>();
            int opcion;

            do
            {
                Console.WriteLine("\n PARTE I: NAVEGADOR WEB (PILA)");
                Console.WriteLine("1. Visitar nueva página (Push)");
                Console.WriteLine("2. Regresar a la página anterior (Pop)");
                Console.WriteLine("3. Mostrar historial actual");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1:
                        VisitarPagina(historial);
                        break;
                    case 2:
                        RegresarPaginaAnterior(historial);
                        break;
                    case 3:
                        MostrarHistorial(historial);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }

        // Operación Push - Complejidad: O(1)
        static void VisitarPagina(Stack<string> historial)
        {
            Console.Write("Ingrese la URL o nombre de la página: ");
            string url = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(url))
            {
                Console.WriteLine("Error: Debe ingresar una dirección válida.");
                return;
            }

            // Apila la nueva página en la cima de la pila
            historial.Push(url.Trim());
            Console.WriteLine($"Visitando ahora: {url.Trim()}");
        }

        // Operación Pop - Complejidad: O(1)
        static void RegresarPaginaAnterior(Stack<string> historial)
        {
            // Validación para evitar subdesbordamiento (underflow) si la pila está vacía
            if (historial.Count == 0)
            {
                Console.WriteLine("El historial está vacío. No hay páginas a las que regresar.");
                return;
            }

            // Retira la página actual (la última que entró)
            string paginaCerrada = historial.Pop();
            Console.WriteLine($"Regresando desde: {paginaCerrada}");

            // Peek permite ver la nueva cima sin extraerla
            if (historial.Count > 0)
            {
                Console.WriteLine($"Página actual: {historial.Peek()}");
            }
            else
            {
                Console.WriteLine("No quedan más páginas en el historial (pestaña vacía).");
            }
        }

        // Recorrido del historial - Complejidad: O(n)
        static void MostrarHistorial(Stack<string> historial)
        {
            Console.WriteLine("\n Historial de Navegación");
            if (historial.Count == 0)
            {
                Console.WriteLine("No hay páginas registradas en el historial.");
                return;
            }

            int posicion = 1;
            // Al iterar un Stack en C#, se recorre desde la cima (más reciente) hacia la base
            foreach (string pagina in historial)
            {
                string etiqueta = (posicion == 1) ? " <-- [Página Actual]" : "";
                Console.WriteLine($" {posicion}. {pagina}{etiqueta}");
                posicion++;
            }
        }

        // COLAS (QUEUES): ATENCIÓN DE CLIENTES EN UN BANCO
        // Principio FIFO (First In, First Out)

        static void MenuBanco()
        {
            // Se utiliza Queue<string> para asegurar atención en orden exacto de llegada
            Queue<string> filaClientes = new Queue<string>();
            string clienteEnAtencion = null;
            int opcion;

            do
            {
                Console.WriteLine("\n PARTE II: SISTEMA DE BANCO (COLA) ");
                Console.WriteLine("1. Registrar llegada de cliente (Enqueue)");
                Console.WriteLine("2. Atender siguiente cliente (Dequeue)");
                Console.WriteLine("3. Mostrar cliente en atención y clientes en espera");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

                switch (opcion)
                {
                    case 1:
                        AgregarCliente(filaClientes);
                        break;
                    case 2:
                        AtenderCliente(filaClientes, ref clienteEnAtencion);
                        break;
                    case 3:
                        MostrarEstadoBanco(filaClientes, clienteEnAtencion);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }

        // Operación Enqueue - Complejidad: O(1)
        static void AgregarCliente(Queue<string> fila)
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: El nombre del cliente no puede estar vacío.");
                return;
            }

            // Agrega el cliente al final de la cola
            fila.Enqueue(nombre.Trim());
            Console.WriteLine($"Cliente '{nombre.Trim()}' agregado a la fila. (En espera: {fila.Count})");
        }

        // Operación Dequeue - Complejidad: O(1)
        static void AtenderCliente(Queue<string> fila, ref string clienteEnAtencion)
        {
            // Validación para evitar error si no hay clientes esperando
            if (fila.Count == 0)
            {
                clienteEnAtencion = null;
                Console.WriteLine("No hay clientes esperando en la fila.");
                return;
            }

            // Extrae al primer cliente que llegó a la cola
            clienteEnAtencion = fila.Dequeue();
            Console.WriteLine($"Llamando a ventanilla -> Atendiendo a: {clienteEnAtencion}");
        }

        // Recorrido de la cola - Complejidad: O(n)
        static void MostrarEstadoBanco(Queue<string> fila, string clienteEnAtencion)
        {
            Console.WriteLine("\n Estado Actual de Atención");

            // Mostrar el cliente que está siendo atendido en este momento
            if (clienteEnAtencion != null)
            {
                Console.WriteLine($"Cliente siendo atendido: {clienteEnAtencion}");
            }
            else
            {
                Console.WriteLine("Cliente siendo atendido: Ninguno (ventanilla libre)");
            }

            // Listar los clientes que siguen esperando en orden FIFO
            Console.WriteLine($"\nClientes en espera ({fila.Count}):");
            if (fila.Count == 0)
            {
                Console.WriteLine(" La fila está vacía.");
                return;
            }

            int turno = 1;
            foreach (string cliente in fila)
            {
                Console.WriteLine($" Turno {turno}: {cliente}");
                turno++;
            }
        }
    }
}
