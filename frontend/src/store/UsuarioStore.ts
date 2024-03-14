import { defineStore } from 'pinia';
import sha256 from 'crypto-js/sha256';

interface Usuario {
  usuario: string;
  contrasena: string;
}

interface NuevoUsuario {
  nombre: string;
  correoElectronico: string;
  contrasena: string;
  rol: number;
}

interface Reserva {
  reservaID: number;
  tituloPelicula: string;
  salaID: number;
  horaSesion: string;
  numerosAsiento: number[];
}

interface UsuarioState {
  logueado: boolean;
  currentUser: any; 
  reservas: Reserva[];
}

export const useUsuariosStore = defineStore({
  id: 'usuarios',
  state: (): UsuarioState => ({
    logueado: localStorage.getItem('logueado') === 'true',
    currentUser: JSON.parse(localStorage.getItem('currentUser') || 'null'),
    reservas: [],
  }),
  actions: {
    async login(usuarioLogueandose: Usuario) {
      try {
        const ContraHasheada = sha256(usuarioLogueandose.contrasena).toString();
        const ContraHasheadaBase64 = btoa(ContraHasheada);

        const response = await fetch('http://localhost:8001/Auth/Login', {
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
    async register(nuevoUsuario: NuevoUsuario) {
      try {
        const ContraHasheada = sha256(nuevoUsuario.contrasena).toString();

        const response = await fetch('http://localhost:8001/Auth/Register', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            nombre: nuevoUsuario.nombre,
            correoElectronico: nuevoUsuario.correoElectronico,
            contrasena: ContraHasheada,
            rol: nuevoUsuario.rol,
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
    async logout() {
      this.logueado = false;
      this.currentUser = null;
      localStorage.removeItem('logueado');
      localStorage.removeItem('currentUser');
    },
     
    async cargarReservas() {
      try {
        const response = await fetch(`http://localhost:8001/Usuario/${this.currentUser.usuarioID}/Reservas`);

        if (response.ok) {
          const reservas = await response.json();
          this.reservas = reservas;
        } else {
          console.error('Error al cargar reservas:', response.statusText);
          throw new Error('Error al cargar reservas: ' + response.statusText);
        }
      } catch (error) {
        console.error('Error al cargar reservas:', error);
        throw error;
      }
    },
    CambiarFormatoFechaHora(stringDeDateTime: string) {
      const opciones: Intl.DateTimeFormatOptions = {
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
      };
      const dateTime = new Date(stringDeDateTime);
      return dateTime.toLocaleString('es-ES', opciones);
    },
  },
});
