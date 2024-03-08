namespace ApiPeliculas.Business.Services
{   
    using ApiPeliculas.Modelos;
    using ApiPeliculas.Data;
    using System.Collections.Generic;

    public class SalaService : ISalaService
    {
        private readonly ISalaData _salaData;
        private readonly PeliculaContext _context; 

        public SalaService(ISalaData salaData, PeliculaContext context)
        {
            _salaData = salaData;
            _context = context;
        }

        public List<SalaDTO> ObtenerSalas()
        {
            return _salaData.ObtenerSalas();
        }

        public SalaDTO ObtenerSala(int id)
        {
            return _salaData.ObtenerSala(id);
        }

        public void CrearSala(SalaCrearDTO salaCrearDTO)
        {
            var sala = new Sala
            {
                NombreSala = salaCrearDTO.NombreSala,
                Butacas = new List<Butaca>()
            };
            //Creacion de las 60 butacas por defecto para la nueva sala
            for (int i = 1; i <= 60; i++)
            {
                sala.Butacas.Add(new Butaca{

                });
            }
            _salaData.CrearSala(sala);
        }
    }
}