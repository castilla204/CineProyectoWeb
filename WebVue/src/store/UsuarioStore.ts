import { defineStore } from 'pinia';
import sha256 from 'crypto-js/sha256';

export const useUsuariosStore = defineStore({
  id: 'usuarios',
  state: () => ({
    loggedIn: false,
    currentUser: null,
  }),
  actions: {
    async login(credenciales) {
      try {
        const ContraHasheada = sha256(credenciales.contrasena).toString();
        const ContraHasheadaBase64 = btoa(ContraHasheada);

        const response = await fetch('http://localhost:8001/Usuario/login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            usuario: credenciales.usuario,
            passwordHasheada: ContraHasheadaBase64,
          }),
        });

        if (response.ok) {
          const userData = await response.json();
          this.loggedIn = true;
          this.currentUser = userData;
        } else {
          console.error('Error al iniciar sesion:', response.statusText);
          this.loggedIn = false;
          this.currentUser = null;
          throw new Error('Error al iniciar sesión: ' + response.statusText);
        }
      } catch (error) {
        console.error('Error al iniciar sesión:', error);
        this.loggedIn = false;
        this.currentUser = null;
        throw error;
      }
    },
    async register(nuevoUsuario) {
      try {
        const ContraHasheada = sha256(nuevoUsuario.contrasena).toString();

        const response = await fetch('http://localhost:8001/Usuario', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            nombre: nuevoUsuario.nombre,
            correoElectronico: nuevoUsuario.correoElectronico,
            contrasena: ContraHasheada,
            rol: nuevoUsuario.rol
          }),
        });

        if (response.ok) {
          console.log('Usuario registrado exitosamente');
        } else {
          console.error('Error al registrar usuario:', response.statusText);
          throw new Error('Error al registrar usuario: ' + response.statusText); 
        }
      } catch (error) {
        console.error('Error al registrar usuario:', error);
        throw error; 
      }
    },
    logout() {
      this.loggedIn = false;
      this.currentUser = null;
    },
  },
});