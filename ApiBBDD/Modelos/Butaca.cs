namespace ApiPeliculas.Modelos{
public class Butaca{
        public int ButacaId { get; set; } //Clave Principal
        public int SalaID { get; set; } //Clave Foranea
        public EstadoButaca Estado { get; set; }
}

}