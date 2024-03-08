import { defineStore } from 'pinia';

export const usePeliculasStore = defineStore({
  id: 'movies',
  state: () => ({
    peliculas: [],
    isLoading: false,
    pelicula: null,
  }),
  actions: {
    async obtenerPeliculas() {
      this.isLoading = true;
      try {
        const response = await fetch('http://localhost:8001/Pelicula');
        this.peliculas = await response.json();
        this.isLoading = false;
      } catch (error) {
        console.error("Error al obtener películas:", error);
        this.isLoading = false;
      }
    },
  },
});