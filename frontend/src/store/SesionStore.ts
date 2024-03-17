
import { defineStore } from 'pinia';


export interface Pelicula {
  titulo: string;
  descripcion: string;
  imagen: string;
  director: string;
  actores: string;
}

export interface Sesion {
  sesionID: number;
  fechaHora: string;
  nombreSala: string;
  butacasOcupadas: number;
}


export const useSesionesStore = defineStore({
  id: 'sesion', 
  state: () => ({
    sesiones: [] as Sesion[], 
    pelicula: null as Pelicula | null, 
  }),
  actions: {
    async obtenerSesionesPelicula(movieId: number) { // obtener las sesiones de una película
      this.pelicula = null; // reiniciar la información de la película
      this.sesiones = []; // reiniciar las sesiones

      try {
        if (!movieId) throw new Error('ID de la película inválido'); 
        const response = await fetch(`http://localhost:8001/Pelicula/${movieId}/Sesiones`); 
        if (!response.ok) throw new Error('La respuesta del servidor no es válida'); 
        const sesionesData = await response.json(); 

        if (sesionesData.length > 0) { // si hay sesiones disponibles
          const { tituloPelicula, descripcionPelicula, imagenPelicula, directorPelicula, actoresPelicula  } = sesionesData[0];
          this.pelicula = { titulo: tituloPelicula, descripcion: descripcionPelicula, imagen: imagenPelicula, director: directorPelicula, actores:actoresPelicula }; // actualiza la información de la película
        }

        this.sesiones = sesionesData.map((sesion: any) => ({
          sesionID: sesion.sesionID,
          fechaHora: this.cambiarFormatoFechaHora(sesion.fechaHora),
          nombreSala: sesion.nombreSala,
          butacasOcupadas: sesion.butacasOcupadasIds.length,
        }));
      } catch (error) { 
        console.error('Error obteniendo las sesiones de la película:', error); 
      }
    },
    cambiarFormatoFechaHora(stringDeDateTime: string) { 
      const opciones: Intl.DateTimeFormatOptions = { 
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
      };
      const dateTime = new Date(stringDeDateTime); 
      return dateTime.toLocaleString('es-ES', opciones); 
    },
  },
});