import { defineStore } from 'pinia';

export const SesionesStore = defineStore({
  id: 'session',
  state: () => ({
    sessions: [],
  }),
  actions: {
    async ObtenerSesionesPelicula(movieId: number) {
      try {
        if (!movieId) {
          throw new Error('Invalid movieId');
        }
        const response = await fetch(`http://localhost:8001/Sesion/Pelicula/${movieId}`);
        if (!response.ok) {
          throw new Error('Invalid data returned');
        }
        const sesionesData = await response.json();

        const sessions = sesionesData.map((session: any) => ({
          sesionID: session.sesionID,
          fechaHora: CambiarFormatoFechaHora(session.fechaHora), 
          tituloPelicula: session.tituloPelicula,
          nombreSala: session.nombreSala,
          imagenPelicula: session.imagenPelicula,
          butacasOcupadasIds: session.butacasOcupadasIds,
        }));

        this.sessions = sessions;
      } catch (error) {
        console.error('Error fetching sessions:', error);
      }
    },
  },
});


function CambiarFormatoFechaHora(StringdeDateTime: string) {
  const options = {
    weekday: undefined,
    year: 'numeric',
    month: 'long',
    day: 'numeric',
    hour: '2-digit',
    minute: '2-digit',
  };
  const dateTime = new Date(StringdeDateTime);
  return dateTime.toLocaleString('es-ES', options);
}