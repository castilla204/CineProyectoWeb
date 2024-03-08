
using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{

public class ButacaService: IButacaService{
private readonly IButacaData _butacaData;

public ButacaService(IButacaData ButacaData){
    _butacaData=ButacaData;
}

public List <Butaca> ObtenerButacas(){
    return _butacaData.ObtenerButacas();
}

public List <Butaca> ObtenerButacasOcupadas(){
   return _butacaData.ObtenerButacasOcupadas();
}




}}