namespace ApiPeliculas.Modelos
{
    public class Butaca
    {
        public int ButacaID { get; set; }
        public int SalaID { get; set; }
        public ICollection<ReservaButaca> ReservaButacas { get; set; } = new HashSet<ReservaButaca>();

        public Sala Sala { get; set; }
    }
}