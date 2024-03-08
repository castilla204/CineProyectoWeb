using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace ApiPeliculas.Data{
public class SesionData: ISesionData{

private readonly PeliculaContext _context;
public SesionData(PeliculaContext context){

_context=context;

}

public List<SesionDTO> ObtenerSesionesDTO()
{
    var sesionesDTO = _context.Sesiones
        .Include(s => s.Pelicula)
        .Include(s => s.Sala).ThenInclude(sala => sala.Butacas) 
        .Include(s => s.Reservas).ThenInclude(reserva => reserva.Butaca) // Incluir las reservas para ver las butacas.
        .Select(s => new SesionDTO
        {
            SesionID = s.SesionID,
            FechaHora = s.FechaHora,
            TituloPelicula = s.Pelicula.Titulo,
            NombreSala = s.Sala.NombreSala,
            ImagenPelicula = s.Pelicula.Imagen,
            ButacasOcupadasIds = s.Reservas
                                  .Select(r => r.ButacaID) // seleccionar las butacas para la sesion especifica.
                                  .ToList()
        })
        .ToList();

    return sesionesDTO;
}
    public SesionDTO ObtenerSesion(int id)
    {
        var sesionDTO = _context.Sesiones
            .Where(s => s.SesionID == id) // Filtrar por el ID de la sesion
            .Include(s => s.Pelicula)
            .Include(s => s.Sala).ThenInclude(sala => sala.Butacas) // Incluir las butacas para tener su contexto
            .Include(s => s.Reservas).ThenInclude(reserva => reserva.Butaca) // Incluir las reservas para acceder a las butacas específicas
            .Select(s => new SesionDTO
            {
                SesionID = s.SesionID,
                FechaHora = s.FechaHora,
                TituloPelicula = s.Pelicula.Titulo,
                NombreSala = s.Sala.NombreSala,
                ImagenPelicula = s.Pelicula.Imagen,
                ButacasOcupadasIds = s.Reservas
                                    .Select(r => r.ButacaID) // Seleccionar todas las butacas reservadas para esta sesión específica.
                                    .ToList()
        
            })
            .FirstOrDefault(); 

        return sesionDTO;
    }

    public List<SesionDTO> ObtenerSesionesPeli(int IdPelicula)
    {
        var sesionesPeliDTO = _context.Sesiones
            .Where(s => s.PeliculaID == IdPelicula)
            .Select(s => new SesionDTO
            {
                SesionID = s.SesionID,
                FechaHora = s.FechaHora,
                TituloPelicula = s.Pelicula.Titulo,
                NombreSala = s.Sala.NombreSala,
                ImagenPelicula = s.Pelicula.Imagen,
                ButacasOcupadasIds = s.Reservas
                                    .Select(r => r.ButacaID)
                                    .ToList()
            })
            .ToList();

        return sesionesPeliDTO;
    }

        
    

    public void CrearSesion(Sesion sesion){
        _context.Sesiones.Add(sesion);
        _context.SaveChanges();
    }

}}