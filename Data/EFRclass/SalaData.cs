namespace ApiCine.Data{
    using ApiCine.Modelos;
    using Microsoft.EntityFrameworkCore;

    public class SalaData: ISalaData{
    
    private readonly Context _context;
    public SalaData(Context context){
        _context=context;
    }

       public List<SalaDTO> ObtenerSalas()
        {
            var salasDTO = _context.Salas
                .Include(s => s.Sesiones)
                .Select(s => new SalaDTO
                {
                    SalaID = s.SalaID,
                    NombreSala = s.NombreSala,
                    SesionesIds = s.Sesiones.Select(sess => sess.SesionID).ToList() 
                }).ToList();

            return salasDTO;
        }

    public SalaDTO ObtenerSala(int id)
{
    var salaDTO = _context.Salas
        .Where(s => s.SalaID == id)
        .Include(s => s.Sesiones)
        .Select(s => new SalaDTO
        {
            SalaID = s.SalaID,
            NombreSala = s.NombreSala,
            SesionesIds = s.Sesiones.Select(sess => sess.SesionID).ToList()
        })
        .FirstOrDefault();

    return salaDTO;
}

    public void CrearSala(Sala sala){
    _context.Salas.Add(sala);
    _context.SaveChanges();
    }
    }
}