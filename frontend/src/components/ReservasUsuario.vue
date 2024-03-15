<template>
  <div class="general">
    <div class="contenido">
      <h2 class="titulo">{{ $t('ReservasUsuario.text1') }}</h2>
      <div class="table-container">
        <table class="reservas-table">
          <thead>
            <tr>
              <th>{{ $t('ReservasUsuario.text2') }}</th>
              <th>{{ $t('ReservasUsuario.text3') }}</th>
              <th>{{ $t('ReservasUsuario.text4') }}</th>
              <th>{{ $t('ReservasUsuario.text5') }}</th>
              <th>{{ $t('ReservasUsuario.text6') }}</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="reserva in reservas" :key="reserva.reservaID">
              <td>{{ reserva.reservaID }}</td>
              <td>{{ reserva.tituloPelicula }}</td>
              <td>{{ reserva.salaID }}</td>
              <td>{{ formatHora(reserva.horaSesion) }}</td>
              <td>{{ reserva.numerosAsiento.join(', ') }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
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

const formatHora = (hora: string): string => {
  const date = new Date(hora);
  const options: Intl.DateTimeFormatOptions = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric', hour12: true };
  return date.toLocaleString('es-ES', options);
};
</script>

<style scoped>
.general {
  background-color: #000;
  padding: 20px;
  font-family: 'Helvetica', sans-serif;
  color: #000000;
}

.contenido {
  max-width: 800px;
  margin: auto;
}

.titulo {
  font-size: 1.8rem;
  margin-bottom: 20px;
  text-align: center;
  color: white;
}

.table-container {
  overflow-x: auto;
}

.reservas-table {
  width: 100%;
  border-collapse: collapse;
  background-color: #fff;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.reservas-table th, .reservas-table td {
  padding: 12px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

.reservas-table th {
  background-color: #f2f2f2;
  color: #333;
}

.reservas-table tbody tr:hover {
  background-color: #f9f9f9;
}

@media screen and (max-width: 768px) {
  .contenido {
    padding: 10px;
  }

  .reservas-table th, .reservas-table td {
    padding: 8px;
    font-size: 0.9rem;
  }
}
</style>