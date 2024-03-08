
import { defineStore } from 'pinia';

interface ReservaData {
  sesionID: number;
  usuarioID: number;
  butacasIds: number[];
}

export const useReservaStore = defineStore({
  id: 'reservaStore',
  state: () => ({
    reservas: [],
  }),
  actions: {
    async realizarReserva(reservaData: ReservaData) {
      const response = await fetch('http://localhost:8001/Reserva', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(reservaData)
      });
      
      if (!response.ok) {
        throw new Error('Error al realizar la reserva');
      }
      
    }
  }
});