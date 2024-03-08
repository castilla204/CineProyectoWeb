using System.Collections.Generic;
using ApiPeliculas.Data;
using ApiPeliculas.Modelos;


namespace ApiPeliculas.Business.Services
{
    public class PeliculaService: IPeliculaService
    {
        private readonly IPeliculaData _PeliculaData;
        private readonly PeliculaContext _context;
        
        public PeliculaService(IPeliculaData PeliculaData, PeliculaContext context)
        {
            _context=context;
            _PeliculaData = PeliculaData;
        }

public List<Pelicula> ObtenerPizzas()
{
    return _PeliculaData.ObtenerPizzas();
}


public Pelicula ObtenerPizzaPorID(int id){
   return  _PeliculaData.ObtenerPizzaPorID(id);
}

public void EliminarPizza(int id){
    _PeliculaData.EliminarPizza(id);
}
 
 
    public void CrearPizza(PeliculaDTO peliculaDTO)
    {
        var pelicula = new Pelicula{
            Imagen=peliculaDTO.Imagen,
            Titulo=peliculaDTO.Titulo,
            Director=peliculaDTO.Director,
            Actores=peliculaDTO.Actores,
            Descripcion=peliculaDTO.Descripcion
        };
        
        _PeliculaData.CrearPizza(pelicula);
    }

public void ActualizarPelicula(int id, PeliculaDTO peliculaDTO)
{
        {
        var pelicula = new Pelicula{
            PeliculaID=id,
            Imagen=peliculaDTO.Imagen,
            Titulo=peliculaDTO.Titulo,
            Director=peliculaDTO.Director,
            Actores=peliculaDTO.Actores,
            Descripcion=peliculaDTO.Descripcion
        };
    _PeliculaData.ActualizarPelicula(pelicula);
    
    
}
}
}
}
