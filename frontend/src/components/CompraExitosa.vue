<template>
  <div class="contenedor-popup" v-if="ultimaReserva">
    <div class="popup">
      <div class="contenido-popup">
        <div class="interior-popup">
          <div class="izquierda-popup">
            <img src="/multimedia/pulgarup.png" alt="Imagen de la película" class="imagen-pelicula">
          </div>
          <div class="derecha-popup">
            <h2 class="titulo">{{ $t('CompraExitosa.text1') }}</h2>
            <p class="campo">{{ $t('CompraExitosa.text2') }} {{ ultimaReserva.tituloPelicula }}</p>
            <p class="campo">{{ $t('CompraExitosa.text3') }} {{ ultimaReserva.salaID }}</p>
            <p class="campo">{{ $t('CompraExitosa.text4') }} {{ formatoFechaHora(ultimaReserva.horaSesion) }}</p>
            <p class="campo">{{ $t('CompraExitosa.text5') }} {{ ultimaReserva.numerosAsiento.join(', ') }}</p>
            <p class="campo1">{{ $t('CompraExitosa.text6') }} {{
    calcularPrecioTotal(ultimaReserva.numerosAsiento.length) }} €</p>
            <button @click="irAInicio" class="boton-inicio">{{ $t('CompraExitosa.text7') }}</button>
            <p class="terminos">{{ $t('CompraExitosa.text8') }}</p>
          </div>
        </div>
        <div class="qr-container">
          <img v-if="qrValue" :src="qrValue" alt="Código QR" class="codigo-qr">
          <p class="qr-label">Código QR</p>
        </div>
      </div>
    </div>
  </div>
</template>

  
  <script setup lang="ts">
  import { ref, onMounted } from 'vue';
  import { useUsuariosStore } from '../store/UsuarioStore';
  import router from '../router'; 
  import QRCode from 'qrcode';
  
  const tiendaUsuarios = useUsuariosStore();
  
  const ultimaReserva = ref<Reserva | null>(null);
  const qrValue = ref<string | null>(null);
  
  interface Reserva {
    reservaID: number;
    tituloPelicula: string;
    salaID: number;
    horaSesion: string;
    numerosAsiento: number[];
  }
  
  onMounted(async () => {
    try {
      await tiendaUsuarios.cargarReservas();
      const reservas = tiendaUsuarios.reservas;
      if (reservas.length > 0) {
        ultimaReserva.value = reservas.reduce((prev, current) => (prev.reservaID > current.reservaID ? prev : current));
        const qrData = JSON.stringify(ultimaReserva.value);
        qrValue.value = await generarCodigoQR(qrData);
      }
    } catch (error) {
      console.error('Error al cargar reservas:', error);
    }
  });
  
  const formatoFechaHora = (cadenaFechaHora: string) => {
    const opciones: Intl.DateTimeFormatOptions = {
      year: 'numeric',
      month: 'long',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
    };
    const fechaHora = new Date(cadenaFechaHora);
    return fechaHora.toLocaleString('es-ES', opciones);
  };
  
  const calcularPrecioTotal = (numAsientos: number) => {
    return (numAsientos * 7.5).toFixed(2);
  };
  
  const irAInicio = () => {
    router.push('/');
  };
  
  const generarCodigoQR = async (datos: string) => {
    try {
      return await QRCode.toDataURL(datos);
    } catch (error) {
      console.error('Error al generar el código QR:', error);
      return null;
    }
  };
  </script>
  
  
  <style scoped>
  .contenedor-popup {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: rgba(0, 0, 0, 0.5); 
  }
  
  .campo {
    font-family: 'HelveticaThin';
  }
  
  .campo1 {
    font-family: 'Helvetica';
  }
  
  .popup {
    background-color: white;
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
    max-width: 80%;
    width: 600px; 
  }
  
  .contenido-popup {
    overflow-y: auto; 
  }
  
  .titulo {
    font-family: 'Helvetica';
  }
  
  .interior-popup {
    display: flex;
    align-items: center; 
  }
  
  .izquierda-popup,
  .derecha-popup {
    width: 50%;
  }
  
  .izquierda-popup {
    padding-right: 10px;
  }
  
  .derecha-popup {
    padding-left: 10px;
  }
  
  .imagen-pelicula {
    max-width: 100%;
    height: auto;
    border-radius: 5px;
  }
  
  .boton-inicio {
    background-color: #4CAF50;
    border: none;
    color: white;
    padding: 10px 20px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin-top: 20px;
    cursor: pointer;
    border-radius: 5px;
    font-family: 'Helvetica';
  }
  
  .terminos {
    font-size: 12px;
    margin-top: 10px;
  }
  
  .qr-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-top: 20px;
  }
  
  .qr-label {
    font-family: 'Helvetica';
    font-size: 18px;
    margin-top: 10px;
  }
  
  .codigo-qr {
    width: 200px;
    height: auto;
    border: 1px solid #000;
    border-radius: 5px;
    margin-top: 10px;
  }
  </style>