using ApiPeliculas.Modelos;
using ApiPeliculas.Business.Services;
using Microsoft.AspNetCore.Mvc;


namespace ApiPeliculas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;

        public PeliculaController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        

        [HttpGet]
        public ActionResult<List<PeliculaDTO>> ObtenerPeliculas(){
            return _peliculaService.ObtenerPeliculas();

        }
      

        [HttpGet("{id}")]
        public ActionResult<PeliculaDTO> ObtenerPelicula(int id)
        {
            return _peliculaService.ObtenerPelicula(id);
        }
        
[HttpPost]
public IActionResult CrearPelicula([FromBody]PeliculaCrearDTO peliculaDTO)//se ha creado el dto porque a pesar de poner el [JsonIgnore] al pasar como paramtero el modelo Pelicula Original requeria las dos listas.
{
    if (peliculaDTO == null){
        return BadRequest("Datos de la pelicula no proporcionados");
    }
    _peliculaService.CrearPelicula(peliculaDTO);
    
    return Ok("Pelicula añadida");
}

[HttpPut("{id}")]                                                      //El from body ya he visto que a partir de net3 no seria obligatorio ponerlo pero lo pongo como
public IActionResult ActualizarPelicula(int id,[FromBody] PeliculaCrearDTO peliculaDTO)  //indicativo de que se cogen los datos del body he visto que es buena practica
{  
     if (peliculaDTO == null ){
        return BadRequest("Datos de la pelicula o id invalidos");
    }
    _peliculaService.ActualizarPelicula(id,peliculaDTO);
    
    return Ok("Pelicula añadida");
}


 [HttpDelete("{id}")]
public IActionResult EliminarPelicula(int id){
     _peliculaService.EliminarPelicula(id);
      return Ok($"La pelicula con ID '{id}' ha sido eliminada correctamente");
        }
    
    }
}
