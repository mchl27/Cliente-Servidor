using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsola
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar un nuevo producto");
                Console.WriteLine("2. Ver todos los productos");
                Console.WriteLine("3. Salir");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        await AgregarProducto();
                        break;
                    case "2":
                        await VerProductos();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            }
        }

        private static async Task AgregarProducto()
        {
            Console.Write("Ingrese el nombre del producto: ");
            var nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del producto: ");
            if (!decimal.TryParse(Console.ReadLine(), out var precio))
            {
                Console.WriteLine("Precio no válido.");
                return;
            }

            var nuevoProducto = new
            {
                Nombre = nombre,
                Precio = precio
            };

            var json = JsonConvert.SerializeObject(nuevoProducto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:5001/api/productos", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Producto agregado exitosamente.");
            }
            else
            {
                // Imprimir detalles del error
                var errorDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al agregar el producto: {response.StatusCode}");
                Console.WriteLine($"Detalles del error: {errorDetails}");
            }
        }

        private static async Task VerProductos()
        {
            var response = await client.GetAsync("https://localhost:5001/api/productos");

            if (response.IsSuccessStatusCode)
            {
                var productos = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Productos desde el servidor:");
                Console.WriteLine(productos);
            }
            else
            {
                Console.WriteLine("Error al obtener los productos.");
            }
        }
    }
}
