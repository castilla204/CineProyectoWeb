namespace ApiCine.Modelos
{
    public class UsuarioReservasDTO
    {
        public int ReservaID { get; set; }
        public string TituloPelicula { get; set; }
        public int SalaID { get; set; }
        public DateTime HoraSesion { get; set; }
        public List<int> NumerosAsiento { get; set; }
    }
}