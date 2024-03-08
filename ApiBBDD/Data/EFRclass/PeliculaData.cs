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

        public List<Pelicula> ObtenerPizzas()
        {
            return _context.Peliculas.ToList();
        }

        public Pelicula ObtenerPizzaPorID(int id)
        {
            return _context.Peliculas.Find(id);
        }
        public void CrearPizza(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
        }
            public void ActualizarPelicula(Pelicula pelicula)
        {
            _context.Entry(pelicula).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarPizza(int id)
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