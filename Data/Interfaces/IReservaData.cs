namespace ApiCine.Data
{
    using ApiCine.Modelos;
    using System.Collections.Generic;

    public interface IReservaData
    {
        List<Reserva> ObtenerReservas();
        Reserva ObtenerReservaPorId(int id);
        void CrearReserva(Reserva reserva);
        void ActualizarReserva(Reserva reserva);
        void EliminarReserva(int id);
    }
}