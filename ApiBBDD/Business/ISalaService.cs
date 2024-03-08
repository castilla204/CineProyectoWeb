namespace ApiPeliculas.Business.Services{
using ApiPeliculas.Modelos;
public interface ISalaService{

    public List<SalaDTO> ObtenerSalas();

    public SalaDTO ObtenerSala(int id);
    

    public void CrearSala(SalaCrearDTO sala);

}}