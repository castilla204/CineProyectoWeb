namespace ApiPeliculas.Modelos
{
    public class ReservaButaca
    {
        public int ReservaID { get; set; }
        public int ButacaID { get; set; }
        public Reserva Reserva { get; set; }
        public Butaca Butaca { get; set; }
    }
}