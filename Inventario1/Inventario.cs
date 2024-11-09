using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GestionInventario
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"Precio actualizado: {nombre}"); 
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto eliminado: {nombre}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void FiltrarYOrdenar(decimal precioMinimo)
        {
            var productosFiltrados = productos.Where(p => p.Precio > precioMinimo)
                                               .OrderBy(p => p.Precio)
                                               .ToList(); // Convertir a lista para contar elementos

            if (!productosFiltrados.Any())
            {
                Console.WriteLine("No se encontraron productos que cumplan con el criterio.");
                return;
            }

            Console.WriteLine("Productos filtrados y ordenados:");
            foreach (var producto in productosFiltrados)
            {
                Console.WriteLine(producto);
            }
        }

        public void ContarYAgruparProductos()
        {
            var grupos = productos.GroupBy(p =>
            {
                if (p.Precio < 100) return "Menores a 100";
                else if (p.Precio >= 100 && p.Precio <= 500) return "Entre 100 y 500";
                else return "Mayores a 500";
            });

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"{grupo.Key}: {grupo.Count()} productos");
            }
        }

        public void CrearResumenInventario()
        {
            if (!productos.Any())
            {
                Console.WriteLine("El inventario está vacío. No hay productos para mostrar.");
                return;
            }

            int cantidadProductos = productos.Count;
            decimal promedioPrecios = productos.Average(p => p.Precio); 
            Producto productoCostoso = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
            Producto productoEconomico = productos.OrderBy(p => p.Precio).FirstOrDefault();

            Console.WriteLine("Resumen del Inventario:");
            Console.WriteLine($"Total de productos: {cantidadProductos}");
            Console.WriteLine($"Precio promedio: {promedioPrecios:F2}");
            Console.WriteLine($"Producto más caro: {productoCostoso?.Nombre}, Precio: {productoCostoso?.Precio}");
            Console.WriteLine($"Producto más barato: {productoEconomico?.Nombre}, Precio: {productoEconomico?.Precio}");
        }

        public IEnumerable<Producto> ObtenerProductosPorPrecioMinimo(decimal precioMin)
        {
            return productos
                .Where(p => p.Precio > precioMin) // Cambiado a precioMin
                .OrderBy(p => p.Precio)
                .ToList();
        }
    }
}