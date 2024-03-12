namespace ApiCine.Business.Services{
using ApiCine.Modelos;
public interface ISalaService{

    public List<SalaDTO> ObtenerSalas();

    public SalaDTO ObtenerSala(int id);
    

    public void CrearSala(SalaCrearDTO sala);

}}