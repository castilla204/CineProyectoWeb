using System.Collections.Generic;
using ApiPeliculas.Data;
using ApiPeliculas.Modelos;


namespace ApiPeliculas.Business.Services
{
    public class PeliculaService: IPeliculaService
    {
        private readonly IPeliculaData _PeliculaData;
        private readonly Context _context;
        
        public PeliculaService(IPeliculaData PeliculaData, Context context)
        {
            _context=context;
            _PeliculaData = PeliculaData;
        }

public List<PeliculaDTO> ObtenerPeliculas()
{
    return _PeliculaData.ObtenerPeliculas();
}


public PeliculaDTO ObtenerPelicula(int id){
   return  _PeliculaData.ObtenerPelicula(id);
}

public void EliminarPelicula(int id){
    _PeliculaData.EliminarPelicula(id);
}
 
 
    public void CrearPelicula(PeliculaCrearDTO peliculaDTO)
    {
        var pelicula = new Pelicula{
            Imagen=peliculaDTO.Imagen,
            Titulo=peliculaDTO.Titulo,
            Director=peliculaDTO.Director,
            Actores=peliculaDTO.Actores,
            Descripcion=peliculaDTO.Descripcion
        };
        
        _PeliculaData.CrearPelicula(pelicula);
    }

public void ActualizarPelicula(int id, PeliculaCrearDTO peliculaDTO)
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
