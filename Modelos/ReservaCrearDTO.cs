namespace ApiCine.Modelos
{
    public class ReservaCrearDTO
    {
        public int SesionID { get; set; }
        
        public int UsuarioID { get; set; }
         public List<int> ButacasIds { get; set; } = new List<int>();  
    }
}