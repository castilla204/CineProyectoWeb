using System.ComponentModel.DataAnnotations; 


namespace ApiPeliculas.Modelos{
public class Butaca{

        public int ButacaID { get; set; } //Clave Principal
        public int SalaID { get; set; } //Clave Foranea



        // Propiedad de navegación
        public  ICollection<Reserva> Reservas { get; set; }= new HashSet<Reserva>();// Una Butaca puede tener muchas Reservas

        // Propiedad de navegación inversa: Una Butaca pertenece a una Sala
        public  Sala Sala { get; set; }
}

}