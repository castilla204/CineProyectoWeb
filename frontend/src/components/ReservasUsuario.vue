<template>
  <div class="general">
    <h2>Reservas del Usuario</h2>
    <table>
      <thead>
        <tr>
          <th>ID Reserva</th>
          <th>Título Película</th>
          <th>Sala</th>
          <th>Hora Sesión</th>
          <th>Asientos Reservados</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="reserva in reservas" :key="reserva.reservaID">
          <td>{{ reserva.reservaID }}</td>
          <td>{{ reserva.tituloPelicula }}</td>
          <td>{{ reserva.salaID }}</td>
          <td>{{ reserva.horaSesion }}</td>
          <td>{{ reserva.numerosAsiento.join(', ') }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useUsuariosStore } from '../store/UsuarioStore';

const store = useUsuariosStore();

interface Reserva {
  reservaID: number;
  tituloPelicula: string;
  salaID: number;
  horaSesion: string;
  numerosAsiento: number[];
}

const reservas = ref<Reserva[]>([]);

onMounted(() => {
  if (store.logueado) {
    store.cargarReservas().then(() => {
      reservas.value = store.reservas;
    });
  }
});
</script>

<style scoped>
.general{color:white};
</style>