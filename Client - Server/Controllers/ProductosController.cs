using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Client___Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = new List<Productos>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Productos", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        productos.Add(new Productos
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Precio = reader.GetDecimal(2)
                        });
                    }
                }
            }

            return Ok(productos);
        }


        [HttpPost]
        public async Task<IActionResult> AddProducto([FromBody] Productos nuevoProducto)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Productos (Nombre, Precio) VALUES (@Nombre, @Precio)", connection);
                command.Parameters.AddWithValue("@Nombre", nuevoProducto.Nombre);
                command.Parameters.AddWithValue("@Precio", nuevoProducto.Precio);

                var result = await command.ExecuteNonQueryAsync();

                if (result > 0)
                {
                    return Ok("Producto agregado exitosamente.");
                }
                else
                {
                    return BadRequest("Error al agregar el producto.");
                }
            }
        }

    }
}
