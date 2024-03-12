namespace ApiCine.Business.Services
{
    using ApiCine.Modelos;
    using System.Collections.Generic;

    public interface IReservaService
    {
        List<ReservaDTO> ObtenerReservas();
        ReservaDTO ObtenerReservaPorId(int id);
        void CrearReserva(ReservaCrearDTO reservaCrearDTO);
        void ActualizarReserva(int id, ReservaActualizarDTO reservaActualizarDTO);
        void EliminarReserva(int id);
    }
}