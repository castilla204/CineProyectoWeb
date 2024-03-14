
using System.ComponentModel.DataAnnotations;

namespace ApiCine.Modelos
{
    public class ReservaDTO
    {

        public int ReservaID { get; set; }


        public int SesionID { get; set; }


        public int UsuarioID { get; set; }

        public List<int> ButacasIds { get; set; } = new List<int>();
    }
}