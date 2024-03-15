import { defineStore } from 'pinia';

interface Butaca {
  id: number;
  ocupada: boolean;
}

export const ButacaStore = defineStore({
  id: 'butacaStore',
  state: () => ({
    butacas: [] as Butaca[],
    imagenPelicula: '',
    fechaHoraSesion: '', 
  }),
  actions: {
    async cargarButacas(sesionID: number) {
      try {
        const response = await fetch(`http://localhost:8001/Sesion/${sesionID}`);
        const data = await response.json();

        this.imagenPelicula = data.imagenPelicula;
        this.fechaHoraSesion = new Date(data.fechaHora).toISOString(); // Cambio en el formato de fecha y hora
        
        const idInicial = (data.nombreSala.includes('Sala ') ? parseInt(data.nombreSala.split('Sala ')[1]) - 1 : 0) * 60 + 1;
        const idFinal = idInicial + 59;

        this.butacas = [];
        for (let i = idInicial; i <= idFinal; i++) {
          this.butacas.push({ id: i, ocupada: false });
        }

        for (const butaca of data.butacasOcupadasIds) {
          const index = butaca - idInicial;
          if (index >= 0 && index < this.butacas.length) {
            this.butacas[index].ocupada = true;
          }
        }
      } catch (error) {
        console.error('Error al cargar butacas:', error);
      }
    },
    comprobarButaca(id: Number) {
      const index = this.butacas.findIndex(b => b.id === id);
      if (index !== -1) {
        this.butacas[index].ocupada = !this.butacas[index].ocupada;
      }
    },
  },
});