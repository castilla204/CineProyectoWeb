using ApiCine.Data;
using ApiCine.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiCine.Data
{
    public class PeliculaData : IPeliculaData
    {
        private readonly Context _context;

        public PeliculaData(Context context)
        {
            _context = context;
        }

        public List<PeliculaDTO> ObtenerPeliculas()
        {
            var peliculasDTO= _context.Peliculas.
            Include(p => p.Sesiones)
            .Select(p => new PeliculaDTO{
                PeliculaID=p.PeliculaID,
                Titulo=p.Titulo,
                Actores=p.Actores,
                Descripcion=p.Descripcion,
                Director=p.Director,
                Imagen=p.Imagen
            }).ToList();

            return peliculasDTO;
        }

        public PeliculaDTO ObtenerPelicula(int id)
        {
            var peliculaDTO= _context.Peliculas.
            Where(p => p.PeliculaID==id)
            .Include(p => p.Sesiones)
            .Select(p => new PeliculaDTO{
                PeliculaID=p.PeliculaID,
                Titulo=p.Titulo,
                Actores=p.Actores,
                Descripcion=p.Descripcion,
                Director=p.Director,
                Imagen=p.Imagen
            }).FirstOrDefault();
            return peliculaDTO;
        }

        public List<PeliculaSesionesDTO> ObtenerPeliculaSesiones(int id)
{
    var peliculaSesionesDTO = _context.Sesiones
        .Where(s => s.PeliculaID == id)
        .Select(s => new PeliculaSesionesDTO
        {
            SesionID = s.SesionID,
            FechaHora = s.FechaHora,
            TituloPelicula = s.Pelicula.Titulo,
            NombreSala = s.Sala.NombreSala,
            ImagenPelicula = s.Pelicula.Imagen,
            DescripcionPelicula = s.Pelicula.Descripcion,
            ButacasOcupadasIds = s.Reservas
                                  .SelectMany(r => r.ReservaButacas)
                                  .Select(rb => rb.ButacaID)
                                  .ToList()
        })
        .ToList();

    return peliculaSesionesDTO;
}


        public void CrearPelicula(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
        }
            public void ActualizarPelicula(Pelicula pelicula)
        {
            _context.Entry(pelicula).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarPelicula(int id)
        {
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                _context.SaveChanges();
            }
        }



    }
}