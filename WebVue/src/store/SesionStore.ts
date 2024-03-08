import { defineStore } from 'pinia';

export const SesionesStore = defineStore({
  id: 'sesion',
  state: () => ({
    sesiones: [],
  }),
  actions: {
    async ObtenerSesionesPelicula(movieId: number) {
      try {
        if (!movieId) {
          throw new Error('Id de la pelicula invalido');
        }
        const response = await fetch(`http://localhost:8001/Sesion/Pelicula/${movieId}`);
        if (!response.ok) {
          throw new Error('La respuesta es nula');
        }
        const sesionesData = await response.json();

        const sesiones = sesionesData.map((sesion: any) => ({
          sesionID: sesion.sesionID,
          fechaHora: CambiarFormatoFechaHora(sesion.fechaHora), 
          tituloPelicula: sesion.tituloPelicula,
          nombreSala: sesion.nombreSala,
          imagenPelicula: sesion.imagenPelicula,
          descripcionPelicula: sesion.descripcionPelicula,
          butacasOcupadasIds: sesion.butacasOcupadasIds,

        }));

        this.sesiones = sesiones;
      } catch (error) {
        console.error('error haciendo el fecth', error);
      }
    },
  },
});


function CambiarFormatoFechaHora(StringdeDateTime: string) {
  const opciones = {
    weekday: undefined,
    year: 'numeric',
    month: 'long',
    day: 'numeric',
    hour: '2-digit',
    minute: '2-digit',
  };
  const dateTime = new Date(StringdeDateTime);
  return dateTime.toLocaleString('es-ES', opciones);
}