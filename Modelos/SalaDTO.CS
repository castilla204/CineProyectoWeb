namespace ApiCine.Modelos{
public class SalaDTO
{
    public int SalaID { get; set; }
    public string NombreSala { get; set; }
    public List<int> SesionesIds { get; set; } = new List<int>(); 

}}