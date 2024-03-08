import { defineStore } from 'pinia';
import sha256 from 'crypto-js/sha256';

export const useUsuariosStore = defineStore({
  id: 'usuarios',
  state: () => ({
    logueado: localStorage.getItem('logueado') === 'true',
    currentUser: JSON.parse(localStorage.getItem('currentUser') || 'null'),
  }),
  actions: {
    async login(usuarioLogueandose) {
      try {
        const ContraHasheada = sha256(usuarioLogueandose.contrasena).toString();
        const ContraHasheadaBase64 = btoa(ContraHasheada);

        const response = await fetch('http://localhost:8001/Usuario/login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            usuario: usuarioLogueandose.usuario,
            passwordHasheada: ContraHasheadaBase64,
          }),
        });

        if (response.ok) {
          const userData = await response.json();
          this.logueado = true;
          this.currentUser = userData;
          localStorage.setItem('logueado', 'true');
          localStorage.setItem('currentUser', JSON.stringify(userData));
        } else {
          console.error('Error al iniciar sesión:', response.statusText);
          this.logueado = false;
          this.currentUser = null;
          localStorage.removeItem('logueado');
          localStorage.removeItem('currentUser');
          throw new Error('Error al iniciar sesión: ' + response.statusText);
        }
      } catch (error) {
        console.error('Error al iniciar sesión:', error);
        this.logueado = false;
        this.currentUser = null;
        localStorage.removeItem('logueado');
        localStorage.removeItem('currentUser');
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
      this.logueado = false;
      this.currentUser = null;
      localStorage.removeItem('logueado');
      localStorage.removeItem('currentUser');
    },
  },
});