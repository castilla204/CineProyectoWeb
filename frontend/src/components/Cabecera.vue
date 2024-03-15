<template>
  <header>
    <nav class="header">
      <div class="left">
        <img src="/multimedia/logo.svg" class="logocine">
      </div>
      <button @click="DesplegarMenu" class="menu-button">
        <img src="/multimedia/menu.png" alt="Menú" />
      </button>

      <ul :class="{ 'right': true, 'show': menuAbierto }"> 
        <li>
          <button @click="cambiarIdioma" class="nav__link language-button">{{ currentLanguage }}</button>
        </li>
        <li><router-link to="/" class="pelis">{{ $t('Cabecera.text1') }}</router-link></li>
        <li v-if="!usuariologueado"><router-link to="/Auth" class="login">{{ $t('Cabecera.text2') }}</router-link></li>
        <li v-if="usuariologueado"><router-link to="/UsuarioReservas" class="login">{{ $t('Cabecera.text3') }}</router-link></li>
        <li v-if="usuariologueado"><span class="user">{{ $t('Cabecera.text4') }}{{ currentUser.nombre }}</span></li>
        <li v-if="usuariologueado && currentUser.rol === 1"><router-link to="/admin" class="admin">{{ $t('Cabecera.text5') }}</router-link></li>
        <li v-if="usuariologueado"><button @click.prevent="Logout" class="logout" title="Cerrar sesión"><img src="/multimedia/cerrar-sesion.png" alt="Cerrar sesión" /></button></li>
      </ul>
    </nav>
  </header>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';
import { useUsuariosStore } from '../store/UsuarioStore';
import { useRouter } from 'vue-router';
import { useI18n } from 'vue-i18n';

const { t, locale } = useI18n();
const currentLanguage = computed(() => locale.value === 'en' ? 'Español' : 'English');

const cambiarIdioma = () => {
  locale.value = locale.value === 'en' ? 'es' : 'en';
}

const store = useUsuariosStore();
const router = useRouter();
const menuAbierto = ref(false);

const usuariologueado = computed(() => store.logueado);
const currentUser = computed(() => store.currentUser);

const Logout = async () => {
  store.logout();
  await router.push({ name: 'HomePage' });
};

const DesplegarMenu = () => {
  menuAbierto.value = !menuAbierto.value;
};
</script>

<style scoped>
.header {
  background-color: rgb(196, 0, 0);
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-family: 'Helvetica', sans-serif;
  padding: 10px 20px;
}

.logocine {
  height: 50px;
}

.right {
  display: flex;
  flex-direction: row;
  align-items: center;
  list-style: none;
  transition: transform 0.3s ease;
}

.right.show {
  display: flex;
}

.menu-button {
  display: none;
  background: none;
  border: none;
}

.right a,
.right button {
  color: white;
  text-decoration: none;
  margin: 0 15px;
  background: none;
  border: none;
  cursor: pointer;
}

.logout img,
.menu-button img {
  height: 25px;
  width: auto;
}

.language-button {
  background-color: transparent;
  border: 2px solid white;
  border-radius: 50%;
  cursor: pointer;
  font-size: 16px;
  width: 40px;
  height: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.language-button:hover {
  background-color: rgba(255, 255, 255, 0.2);
}

.language-button:focus {
  outline: none;
}

.language-button img {
  width: 24px;
  height: 24px;
}

@media (max-width: 768px) {
  .right {
    position: absolute;
    right: 0;
    top: 60px;
    flex-direction: column;
    background-color: rgb(196, 0, 0);
    width: 100%;
    transform: translateY(-100%);
    transition: transform 0.3s ease;
    display: none;
  }

  .right.show {
    transform: translateY(0);
    display: flex;
  }

  .menu-button {
    display: block;
    cursor: pointer;
  }

  .right a,
  .right button {
    text-align: center;
    margin: 10px 0;
  }
}
</style>