using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiPeliculas.Data
{
    public class PeliculaData : IPeliculaData
    {
        private readonly PeliculaContext _context;

        public PeliculaData(PeliculaContext context)
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