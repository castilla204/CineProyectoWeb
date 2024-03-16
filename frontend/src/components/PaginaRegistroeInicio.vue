<template>
  <div class="contenedor">
    <div class="formulario-inicio">
      <h2 class="titulo"> {{ $t('PaginaRegistro.text1') }}</h2>
      <form @submit.prevent="IniciodeSesion" class="formulario">
        <input type="text" v-model="datosLogin.usuario" :placeholder="$t('PaginaRegistro.textPlaceholder1')" required>
        <input type="password" v-model="datosLogin.contrasena" :placeholder="$t('PaginaRegistro.textPlaceholder2')">
        <button type="submit" class="boton-enviar">{{ $t('PaginaRegistro.text1') }}</button>
      </form>
    </div>
    <div v-if="logueado" class="formulario-bienvenida">
      <p>{{ $t('PaginaRegistro.text4') }}{{ currentUser?.nombre }}</p>
      <button @click="logout">{{ $t('PaginaRegistro.text2') }}</button>
    </div>
    <div class="formulario-registro">
      <h2 class="titulo">Registrarse</h2>
      <form @submit.prevent="Registro" class="formulario">
        <input type="text" v-model="datosRegistro.nombre" :placeholder="$t('PaginaRegistro.textPlaceholder1')" required>
        <input type="email" v-model="datosRegistro.correoElectronico" placeholder="Correo electrónico" required>
        <input type="password" v-model="datosRegistro.contrasena" placeholder="Contraseña" required>
        <button type="submit" class="boton-enviar">Registrarse</button>
        <p v-if="registroExitoso" class="exito-mensaje">Cuenta creada con exito!</p>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { useUsuariosStore } from '../store/UsuarioStore';

const usuariosStore = useUsuariosStore();
const { logueado, currentUser, login, register, logout } = usuariosStore;
const router = useRouter();

const datosLogin = ref({
  usuario: '',
  contrasena: ''
});

interface NuevoUsuario {
  nombre: string;
  correoElectronico: string;
  contrasena: string;
  rol: number; 
}

const datosRegistro = ref<NuevoUsuario>({
  nombre: '',
  correoElectronico: '',
  contrasena: '',
  rol: 0 
});

const registroExitoso = ref(false);

const IniciodeSesion = async () => {
  try {
    await login(datosLogin.value);
    router.push('/');
  } catch (error) {
    alert('Error al iniciar sesión');
  }
};

const Registro = async () => {
  try {
    await register(datosRegistro.value); 
    registroExitoso.value = true;
  } catch (error) {
    alert('Error al registrar');
  }
};
</script>


<style scoped>
.exito-mensaje{
  font-family: 'Helvetica';
  color: #0f4b00;
  margin-top: 5px;
}
.contenedor {
  display: flex;
  justify-content: center;
  align-items: stretch;
  gap: 2rem;
  padding: 2rem;
  flex-direction: flex; 
}

.formulario-inicio, .formulario-registro, .formulario-bienvenida {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 2rem;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  background-color: #f9f9f9;
  width: 100%; 
  max-width: 400px; 
}

.formulario h2 {
  margin-bottom: 1.5rem;
}

.titulo {
  margin-bottom: 20px;
  font-family: 'Helvetica';
}

.formulario input[type="text"],
.formulario input[type="email"],
.formulario input[type="password"],
.formulario input[type="number"] {
  width: 100%;
  margin-bottom: 1rem;
  padding: 0.8rem;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.boton-enviar {
  width: 100%;
  padding: 0.8rem;
  background-color: #af4c4c;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.boton-enviar:hover {
  background-color: #57a045;
}


@media (max-width: 768px) {
  .contenedor {
    flex-direction: column;
    padding: 1rem;
    gap: 1rem;
  }

  .formulario-inicio, .formulario-registro, .formulario-bienvenida {
    padding: 1rem;
    max-width: 100%; 
  }

  .formulario h2 {
    font-size: 20px; 
  }

  .formulario input[type="text"],
  .formulario input[type="email"],
  .formulario input[type="password"],
  .formulario input[type="number"] {
    padding: 15px;
    font-size: 16px;
  }

  .boton-enviar {
    padding: 15px; 
    font-size: 18px;
  }
}

</style>