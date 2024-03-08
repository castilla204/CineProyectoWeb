<template>
  <div class="general">
    <div class="formulario">
      <h2>Iniciar sesión</h2>
      <form @submit.prevent="IniciodeSesion">
        <input type="text" v-model="loginData.usuario" placeholder="Usuario" required>
        <input type="password" v-model="loginData.contrasena" placeholder="Contraseña" required>
        <button type="submit">Iniciar sesión</button>
      </form>
    </div>
    <div v-if="loggedIn" class="formulario">
      <p>Bienvenido, {{ currentUser.nombre }}</p>
      <button @click="logout">Cerrar sesión</button>
    </div>
    <div class="formulario">
      <h2>Registrarse</h2>
      <form @submit.prevent="Registro">
        <input type="text" v-model="registerData.nombre" placeholder="Nombre" required>
        <input type="email" v-model="registerData.correoElectronico" placeholder="Correo electrónico" required>
        <input type="password" v-model="registerData.contrasena" placeholder="Contraseña" required>
        <input type="number" v-model="registerData.rol" placeholder="Rol" required>
        <button type="submit">Registrarse</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { useUsuariosStore } from '../store/UsuarioStore';

const usuariosStore = useUsuariosStore();
const { loggedIn, currentUser, login, register, logout } = usuariosStore;
const router = useRouter();

const loginData = ref({
  usuario: '',
  contrasena: ''
});

const registerData = ref({
  nombre: '',
  correoElectronico: '',
  contrasena: '',
  rol: 0
});

const IniciodeSesion = async () => {
  try {
    await login(loginData.value);
    router.push('/perfil');
  } catch (error) {
    alert('Error al iniciar sesion: ' + error.message);
  }
};

const Registro = async () => {
  try {
    await register(registerData.value);
  } catch (error) {
    alert('Error al registrar: ' + error.message);
  }
};
</script>

<style scoped>

.general {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.formulario {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  border-radius: 10px;
  background-color: #f0f0f0;
}

.formulario h2 {
  margin-bottom: 20px;
}

.formulario input[type="text"],
.formulario input[type="email"],
.formulario input[type="password"],
.formulario input[type="number"] {
  width: 100%;
  margin-bottom: 10px;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.formulario button {
  width: 100%;
  padding: 10px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.formulario button:hover {
  background-color: #0056b3;
}
</style>