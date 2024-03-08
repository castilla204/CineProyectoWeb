namespace ApiPeliculas.Data
{
    using ApiPeliculas.Modelos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class ReservaData : IReservaData
    {
        private readonly PeliculaContext _context;

        public ReservaData(PeliculaContext context)
        {
            _context = context;
        }

        public List<Reserva> ObtenerReservas()
        {
            return _context.Reservas
                .Include(r => r.Sesion)
                .Include(r => r.Usuario)
                .Include(r => r.ReservaButacas) 
                    .ThenInclude(rb => rb.Butaca) 
                .ToList();
        }

        public Reserva ObtenerReservaPorId(int id)
        {
            return _context.Reservas
                .Include(r => r.Sesion)
                .Include(r => r.Usuario)
                .Include(r => r.ReservaButacas) 
                    .ThenInclude(rb => rb.Butaca) 
                .FirstOrDefault(r => r.ReservaID == id);
        }

        public void CrearReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public void ActualizarReserva(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EliminarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                _context.SaveChanges();
            }
        }
    }
}