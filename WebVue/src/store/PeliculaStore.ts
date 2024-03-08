import { defineStore } from 'pinia';

export const PeliculasStore = defineStore('movies', {
  state: () => ({
    peliculas: [],
    isLoading: false,
    pelicula: null,
  }),
  actions: {
    async ObtenerPeliculas() {
      this.isLoading = true;
      try {
        const response = await fetch('http://localhost:8001/Pelicula');
        this.peliculas = await response.json();
        this.isLoading = false;
      } catch (error) {
        console.error(error);
        this.isLoading = false;
      }
    },

    
    async ObtenerPelicula(peliculaID: number) {
      this.isLoading = true;
      try {
        const response = await fetch(`http://localhost:8001/Pelicula/${peliculaID}`);
        this.pelicula = await response.json();
        this.isLoading = false;
      } catch (error) {
        console.error(error);
        this.isLoading = false;
      }
    },
  },
});