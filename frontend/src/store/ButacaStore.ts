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
    //se encarga de crear las butacas en funcion de la sala, y poner las que estan reservadas incluye los 60 objetos butaca con su id y estado en el array butacas
    async cargarButacas(sesionID: number) {
      try {
        const response = await fetch(`http://localhost:8001/Sesion/${sesionID}`);
        const data = await response.json();

        this.imagenPelicula = data.imagenPelicula;
        this.fechaHoraSesion = new Date(data.fechaHora).toISOString(); // para cambiar de date a string
        
        
        const idInicial = (data.nombreSala.includes('Sala ') ? parseInt(data.nombreSala.split('Sala ')[1]) - 1 : 0) * 60 + 1;//si la sala recibida es por ejemplo sala 1 separa sala y el numero y se queda con el numero y le resta uno y lo multiplica por 60 asi obtengop el id de butacainicial en funcion de la sala
        const idFinal = idInicial + 59;


        //crea todas las butacas para la sala metiendo objetos butaca en el array butacas todos inicializo sin ocupar
        this.butacas = []
        for (let i = idInicial; i <= idFinal; i++) {
          this.butacas.push({ id: i, ocupada: false });
        }

        for (const butaca of data.butacasOcupadasIds) {
          const posicionarray = butaca - idInicial; //calcular la posicion del array en el que esta la butaca ocupada
          if (posicionarray >= 0 && posicionarray< this.butacas.length) { //si la posicion del array no es menor a 00 ni mayor de 60 se cambia butaca en esa posicion a ocupada
            this.butacas[posicionarray].ocupada = true;
          }
        }
      } catch (error) {
        console.error('error al cargar butacas:', error);
      }
    }
  },
});