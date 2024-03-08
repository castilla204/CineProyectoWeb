using ApiPeliculas.Modelos;
namespace ApiPeliculas.Data{
    public class ButacaData: IButacaData{
    
    private readonly PeliculaContext _context;

    public ButacaData (PeliculaContext context){
        _context=context;
    }

    public List<Butaca> ObtenerButacas(){
    return _context.Butacas.ToList();
    }
    
    public List<Butaca> ObtenerButacasOcupadas()
    {
        return _context.Butacas.Where(b => b.Estado == EstadoButaca.Ocupada).ToList();
    }


    }
}