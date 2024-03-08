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
public List<Sesion> ObtenerSesiones(){
var sesiones = _context.Sesiones
    .Include(s => s.Pelicula)
    .Include(s => s.Sala)
    .Include(s => s.Reservas) 
    .ToList();
    return sesiones;
}

public Sesion ObtenerSesion(int id){
    var sesion= _context.Sesiones.
              Include(s => s.Pelicula)
              .Include(s => s.Sala)
              .Include(s => s.Reservas)
              .FirstOrDefault(s => s.SesionID == id );
      return sesion;
}


}}