using ApiCine.Modelos;
public interface ISalaData{



    public List<SalaDTO> ObtenerSalas();

    public SalaDTO ObtenerSala(int id);

    public void CrearSala(Sala sala);


}