<template>
  <div class="contenedor">
    <h2 class="titulo">{{ $t('Butacas.text1') }}</h2>
    <div class="contenedorPrincipal">
      <div class="resumen">
        <div class="encabezado">
          <h3 class="detalle-titulo">{{ $t('Butacas.text2') }}</h3>
          <div class="detalle">
            <div class="item">{{ $t('Butacas.text8') }}{{ butacaSeleccionada.length }}</div>
            <div class="item">{{ $t('Butacas.text3') }} {{ butacaSeleccionada.join(", ") }}</div>
            <div class="item">{{ $t('Butacas.text4') }}{{ (butacaSeleccionada.length * 7.5).toFixed(2) }}€</div>
            <div class="item">{{ $t('Butacas.text5') }} {{ formatoFechaHora }}</div>
            <div class="imagen-container">
              <img class="imagenpeli" :src="'/multimedia/' + butacaStore.imagenPelicula" />
            </div>
          </div>
        </div>
        <!-- solo se puede reservra si has seleccionado butacas-->
        <button @click="realizarReserva" :disabled="butacaSeleccionada.length === 0" class="botonReserva">{{
      $t('Butacas.text6') }}</button>
      </div>
      <div class="contenedorButacas">
        <div class="pantallaCine">{{ $t('Butacas.text7') }}</div>
        <div v-for="(fila, filaindex) in filas" :key="filaindex" class="fila">
          <div v-for="butaca in fila" :key="butaca.id" class="butaca-container">
            <span class="butaca-id">{{ butaca.id }}</span>
            <!--la segunda linea del svg pone la clase como "ocupada" si butaca.ocupada es true y como seleccionada si su id esta en el array de seleccionadas-->
            <svg :id="'butaca-' + butaca.id" @click="comprobarButaca(butaca.id)"
              :class="{ 'ocupada': butaca.ocupada, 'seleccionada': butacaSeleccionada.includes(butaca.id) }"            
              xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="100" height="100">
              <path d="M0 0h24v24H0z" fill="none" />
              <path fill="#f4c242" d="M7 10h10v4H7z" />
              <path fill="#f48f42" d="M7 8h10v2H7z" />
              <path fill="#f4af42" d="M4 9h3v6H4zM17 9h3v6h-3z" />
            </svg>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { ButacaStore } from '../store/ButacaStore';
import { useReservaStore } from '../store/ReservaStore';
import { useRouter } from 'vue-router'; 
import { defineProps } from 'vue';



//define el props 
const props = defineProps<{
  sesionID: number;
}>();

const butacaStore = ButacaStore();
const reservaStore = useReservaStore();
const butacas = computed(() => butacaStore.butacas);//se crea una variable butacas que contiene ya el array de butacas con sus estados e id obtenidas desde el butacaStore
const butacaSeleccionada = ref<number[]>([]);
const router = useRouter(); 



//crea un array de arrays en el que dentro de cada array fila estan los objetos butaca para esa fila
const filas = computed(() => { 
  const resultado = [];
  for (let i = 0; i < butacas.value.length; i += 10) {
    resultado.push(butacas.value.slice(i, i + 10));//divide y añade al array las butacas en filas de 10
  }
  return resultado;
});


//se da el  valor de la fecha hora original a fechahorasesion y luego se hace legible a traves de esta variable en Formatofechahora que es la que luego se muestra en el html
const fechaHoraSesion = computed(() => {
  return butacaStore.fechaHoraSesion;
});
const formatoFechaHora = computed(() => {
  const opcionesFechaHora: Intl.DateTimeFormatOptions = {
    weekday: 'long',
    year: 'numeric',
    month: 'long',
    day: 'numeric',
    hour: 'numeric',
    minute: 'numeric'
  };
  const fechaHora = new Date(fechaHoraSesion.value);
  return fechaHora.toLocaleDateString(undefined, opcionesFechaHora);
});

//utiliza el props enviado por el componente padre(la vista) y a traves lka accion del butacasStore cargarButacas se cargan las butacas
onMounted(async () => {
  await butacaStore.cargarButacas(props.sesionID);
});


//se llama cuando se clica la butaca 
const comprobarButaca = (id: number) => {
  const butaca = butacas.value.find(b => b.id === id); //se busca la butaca en el arraybutacas
  if (butaca && !butaca.ocupada) {//se verifica que no este ocupada la butaca que se pasa
    const index = butacaSeleccionada.value.indexOf(id);
    if (index === -1) { //si no encuentra el indexof devuelve -1
      butacaSeleccionada.value.push(id); //si no estaba seleccionada la añade
    } else {
      butacaSeleccionada.value.splice(index, 1);//si estaba seleccionada la quita
    }
  }
};

const realizarReserva = async () => {
  try {
    const usuarioID = obtenerUsuarioIDLocalStorage();//se coge el usuario del localstorage para hacer la reserva

    if (usuarioID !== null) {
      await reservaStore.realizarReserva({ //si podemos coger el usuarioID del localstorage(hay un usuario logueado) se phace la reserva con el id del usuario logueado y redirije al sitio de pago para usuarios logueados
        sesionID: props.sesionID,
        usuarioID: usuarioID,
        butacasIds: butacaSeleccionada.value
      });
    
      router.push({ name: 'PaginaPago' });
    } else {                                 //si el usuario no esta logueado se hace la reserva con el usuario administrador(el 1) yy redirige a una pagina para introducir datos personales
      await reservaStore.realizarReserva({
        sesionID: props.sesionID,
        usuarioID: 1,
        butacasIds: butacaSeleccionada.value
      });
      router.push({ name: 'PaginaPagoNologin' });
    }
  } catch (error) {
    console.error('Error al realizar la reserva:', error);
  }
};

const obtenerUsuarioIDLocalStorage = () => {
  const usuarioString = localStorage.getItem('currentUser');
  if (usuarioString) {
    const usuario = JSON.parse(usuarioString);
    return usuario.usuarioID;
  }
  return null;
};
</script>

<style scoped>
.contenedor {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.contenedorPrincipal {
  display: flex;
  justify-content: center;
  width: 80%;
  margin: 0 auto;
}

.resumen {
  flex: 1;
  margin: 20px;
  background-color: #fff;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 90%;
  max-width: 400px;
  text-align: center;
  padding: 20px;
}

.encabezado {
  margin-bottom: 20px;
}

.detalle-titulo {
  font-family: 'Helvetica';
}

.detalle {
  font-family: 'HelveticaThin';
}

.item {
  margin-bottom: 10px;
}

.imagen-container {
  margin-top: 20px;
}

.imagenpeli {
  height: 300px;
  border-radius: 5px;
}

.contenedorButacas {
  background-color: #f0f0f0;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 4px 8px #0000001a;
  margin: 10px;
  width: 80%;
  max-height: 700px;
}

.titulo {
  font-size: 1.5rem;
  color: #ffffff;
  margin-bottom: 10px;
  font-family: 'Helvetica', sans-serif;
  margin-top: 4%;
  margin-right:35%;
  text-align: center;
}

.fila {
  display: flex;
  justify-content: center;
}

.butaca-container {
  position: relative;
  text-align: center;
  margin: 5px;
  width: 80px; 
}

.butaca-id {
  position: absolute;
  top: 50%;
  left: 50%;
  font-family: 'Helvetica';
  transform: translate(-50%, -50%);
  font-size: 12px;
  color: #333;
  pointer-events: none;
}

.butaca {
  cursor: pointer;
  transition: transform 0.3s ease;
}

.butaca:hover svg {
  transform: scale(1.2);
}
.pantallaCine {
  width: 100%;
  height: 5%;
  background-color: #949494;
  margin: 20px auto;
  border-radius: 2px;
  display: flex;
  justify-content: center;
  align-items: center;
  color: #fff; /* Color del texto */
  font-family: 'Helvetica', sans-serif;
}

.botonReserva {
  background-color: #4caf50;
  color: white;
  padding: 15px 30px;
  text-align: center;
  font-size: 18px;
  margin-top: 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.ocupada path {
  opacity: 20%;
  fill: rgb(255, 30, 0);
}

.seleccionada path {
  opacity: 20%;
  fill: blue;
}

svg {
  width: 80px;
  height: 80px;
}

@media screen and (max-width: 768px) {
  .contenedorPrincipal{
    display: block;
  }

  .resumen{
    width: 90%;
  }
  .contenedorButacas {
    width: 100%;
    padding: 5px;
  }

  .titulo{
    margin-right: 0%;
  }

  .butaca-container {
    width: 100%; 
  }

  svg {
    width: 22px;
    height: 53px;
  }

  .botonReserva {
    padding: 12px 24px;
    font-size: 16px;
  }
}
</style>