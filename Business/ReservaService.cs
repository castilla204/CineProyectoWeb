namespace ApiPeliculas.Business.Services
{
    using ApiPeliculas.Modelos;
    using ApiPeliculas.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class ReservaService : IReservaService
    {
        private readonly IReservaData _reservaData;

        public ReservaService(IReservaData reservaData)
        {
            _reservaData = reservaData;
        }

        public List<ReservaDTO> ObtenerReservas()
        {
            var reservas = _reservaData.ObtenerReservas();
            return reservas.Select(r => new ReservaDTO
            {
                ReservaID = r.ReservaID,
                SesionID = r.SesionID,
                UsuarioID = r.UsuarioID,
                ButacasIds = r.ReservaButacas.Select(rb => rb.ButacaID).ToList() 
            }).ToList();
        }

        public ReservaDTO ObtenerReservaPorId(int id)
        {
            var reserva = _reservaData.ObtenerReservaPorId(id);
            if (reserva != null)
            {
                return new ReservaDTO
                {
                    ReservaID = reserva.ReservaID,
                    SesionID = reserva.SesionID,
                    UsuarioID = reserva.UsuarioID,
                    ButacasIds = reserva.ReservaButacas.Select(rb => rb.ButacaID).ToList() 
                };
            }
            return null;
        }

        public void CrearReserva(ReservaCrearDTO reservaCrearDTO)
        {
            var nuevaReserva = new Reserva
            {
                SesionID = reservaCrearDTO.SesionID,
                UsuarioID = reservaCrearDTO.UsuarioID,
                ReservaButacas = reservaCrearDTO.ButacasIds.Select(butacaId => new ReservaButaca { ButacaID = butacaId }).ToList() 
            };
            _reservaData.CrearReserva(nuevaReserva);
        }

        public void ActualizarReserva(int id, ReservaActualizarDTO reservaActualizarDTO)
        {
            var reservaExistente = _reservaData.ObtenerReservaPorId(id);
            if (reservaExistente != null)
            {
                reservaExistente.SesionID = reservaActualizarDTO.SesionID;
                reservaExistente.UsuarioID = reservaActualizarDTO.UsuarioID;
                _reservaData.ActualizarReserva(reservaExistente);
            }
        }

        public void EliminarReserva(int id)
        {
            _reservaData.EliminarReserva(id);
        }
    }
}