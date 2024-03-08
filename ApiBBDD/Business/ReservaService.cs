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
                ButacaID = r.ButacaID,
                UsuarioID = r.UsuarioID
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
                    ButacaID = reserva.ButacaID,
                    UsuarioID = reserva.UsuarioID
                };
            }
            return null;
        }

        public void CrearReserva(ReservaCrearDTO reservaCrearDTO)
        {
            var nuevaReserva = new Reserva
            {
                SesionID = reservaCrearDTO.SesionID,
                ButacaID = reservaCrearDTO.ButacaID,
                UsuarioID = reservaCrearDTO.UsuarioID
            };
            _reservaData.CrearReserva(nuevaReserva);
        }

        public void ActualizarReserva(int id, ReservaActualizarDTO reservaActualizarDTO)
        {
            var reservaExistente = _reservaData.ObtenerReservaPorId(id);
            if (reservaExistente != null)
            {
                reservaExistente.SesionID = reservaActualizarDTO.SesionID;
                reservaExistente.ButacaID = reservaActualizarDTO.ButacaID;
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