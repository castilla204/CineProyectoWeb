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
    logueado: localStorage.getItem('logueado') === 'true', // recuperar estado logueado localstorage
    currentUser: JSON.parse(localStorage.getItem('currentUser') || 'null'), // recuperar datos usuario localstrogae
    reservas: [], 
  }),
  actions: { 
    async login(usuarioLogueandose: Usuario) { //inicio de sesion
      try {
        // calculae sha256
        const ContraHasheada = sha256(usuarioLogueandose.contrasena).toString();
        const ContraHasheadaBase64 = btoa(ContraHasheada); // Convierte el hash a base64

        
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

        if (response.ok) { // Si la solicitud es exitosa
          const userData = await response.json(); 
          this.logueado = true; 
          this.currentUser = userData; 
          localStorage.setItem('logueado', 'true'); 
          localStorage.setItem('currentUser', JSON.stringify(userData)); // almacena los datos del usuario actual en el localstorage
        } else { //si no
          console.error('Error al iniciar sesión:', response.statusText);
          this.logueado = false; // actualiza el estado de logueado a falso
          this.currentUser = null; 
          localStorage.removeItem('logueado'); 
          localStorage.removeItem('currentUser');  //se quita como logueado y eñl objeto
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
    async register(nuevoUsuario: NuevoUsuario) { // para registrar un nuevo usuario
      try {
        // calcula el sha256 de la contraseña
        const ContraHasheada = sha256(nuevoUsuario.contrasena).toString();

        // hace la solicitud post
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
    async logout() { //para desloguearse
      this.logueado = false; 
      this.currentUser = null; //se ponen los datos del usuario como nulos
      localStorage.removeItem('logueado'); 
      localStorage.removeItem('currentUser'); 
    },
    async cargarReservas() { // para cargar las reservas del usuario en la pagina de reservas del usuario
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