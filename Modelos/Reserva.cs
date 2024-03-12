namespace ApiCine.Modelos
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int SesionID { get; set; }
        public int UsuarioID { get; set; }


        //Propiedades de navegación
        public ICollection<ReservaButaca> ReservaButacas { get; set; } = new HashSet<ReservaButaca>();
        public Sesion Sesion { get; set; }
        public Usuario Usuario { get; set; }
    }
}