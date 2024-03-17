import { defineStore } from 'pinia';

export interface Pelicula {
    id?: number;
    peliculaID: number;
    imagen: string;
    titulo: string;
    director: string;
    actores: string;
    descripcion: string;
}



export const usePeliculasStore = defineStore({
    id: 'movies',
    state: () => ({
        peliculas: [] as Pelicula[],
        isLoading: false,
    }),
    actions: {
        async obtenerPeliculas() {
            this.isLoading = true;
            try {
                const response = await fetch('http://localhost:8001/Pelicula');
                if (!response.ok) {
                    throw new Error('Error al cargar películas');
                }
                const data: Pelicula[] = await response.json(); 
                this.peliculas = data;
            } catch (error) {
                console.error("Error al obtener películas:", error);
            } finally {
                this.isLoading = false;
            }
        },
        async agregarPelicula(pelicula: Pelicula) {
            try {
                const response = await fetch('http://localhost:8001/Pelicula', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(pelicula),
                });
                if (!response.ok) {
                    throw new Error('Error al agregar película');
                }
                // No es necesario llamar a obtenerPeliculas() aquí
            } catch (error) {
                console.error("Error al agregar película:", error);
            }
        },
        async eliminarPelicula(id: number) {
            try {
                const response = await fetch(`http://localhost:8001/Pelicula/${id}`, { method: 'DELETE' });
                if (!response.ok) {
                    throw new Error('Error al eliminar película');
                }
                // No es necesario llamar a obtenerPeliculas() aquí
            } catch (error) {
                console.error("Error al eliminar película:", error);
            }
        },
        async editarPelicula(id: number, pelicula: Pelicula) {
            try {
                const response = await fetch(`http://localhost:8001/Pelicula/${id}`, {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(pelicula),
                });
                if (!response.ok) {
                    throw new Error('Error al editar película');
                }
                await this.obtenerPeliculas(); 
            } catch (error) {
                console.error("Error al editar película:", error);
            }
        },
    },
});