using GestionInventario;
using System;

namespace GestionInventario {
    class Program
    {
        static void Main(string[] args)
        {
            
            Inventario inventario = new Inventario();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Bienvenido al sistema de gestion de inventario");
                Console.WriteLine("\n1. Agregar producto");
                Console.WriteLine("2. Actualizar precio");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Filtrar y ordenar productos");
                Console.WriteLine("5. Contar y agrupar productos");
                Console.WriteLine("6. Reporte resumido");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del producto: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el precio del producto: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal precio) && precio > 0)
                        {
                            inventario.AgregarProducto(new Producto(nombre, precio));
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número positivo.");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese el nombre del producto a actualizar: ");
                        string nombreActualizar = Console.ReadLine();
                        Console.Write("Ingrese el nuevo precio: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio) && nuevoPrecio > 0)
                        {
                            inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número positivo.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese el nombre del producto a eliminar : ");
                        string nombreEliminar = Console.ReadLine();
                        inventario.EliminarProducto(nombreEliminar);
                        break;

                    case "4":
                        Console.Write("Ingrese el precio mínimo para filtrar: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal precioMinimo))
                        {
                            inventario.FiltrarYOrdenar(precioMinimo);
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido. Debe ser un número.");
                        }
                        break;

                    case "5":
                        inventario.ContarYAgruparProductos();
                        break;

                    case "6":
                        inventario.CrearResumenInventario();
                        break;

                    case "7":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
