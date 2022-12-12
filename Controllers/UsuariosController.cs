using Microsoft.AspNetCore.Mvc;

namespace Reto_Netcore.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private static readonly string[] Nombre = new[]
    {
        "Roberto", "Pedro", "Juan", "Carlos", "Matilda", "David", "Milagros"
    };
    private static readonly string[] Cedula = new[]
    {
        "1865412587", "1234785489", "1424642547", "1942785124", "1642987932", "1020973485", "1073408067"
    };

    private readonly ILogger<UsuariosController> _logger;
    public IEnumerable<Usuario> aux = Enumerable.Range(1, 5).Select(index => new Usuario
        {
            Nombre = Nombre[Random.Shared.Next(Nombre.Length)],
            Cedula = TransformBase64(Cedula[Random.Shared.Next(Cedula.Length)])
            
        })
        .ToArray();
    public UsuariosController(ILogger<UsuariosController> logger)
    {
        _logger = logger;
        
    }
    public static string TransformBase64(string cedula)
    {
        var cedulaBase64 = System.Text.Encoding.UTF8.GetBytes(cedula);
        return System.Convert.ToBase64String(cedulaBase64);
    }
    [HttpGet(Name = "GetUsuarios")]
    public IEnumerable<Usuario> Get()
    {
        foreach (var item in aux)
        {
            _logger.LogInformation("||METODO GET||Nombre: " + item.Nombre+"||Cedula: "+ item.Cedula+"||CODIGO 200||");
        }
        return aux;
        
    }
    
    


    
}
