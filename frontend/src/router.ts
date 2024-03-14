import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { useUsuariosStore } from './store/UsuarioStore'; 


import HomePage from './components/Vistas/Homepage.vue';
import PaginaReserva from './components/Vistas/PaginaReserva.vue';
import PaginaPago from './components/Vistas/PaginaPago.vue';
import PaginaLogin from './components/Vistas/PaginaLogin.vue';
import InfoPelicula from './components/Vistas/InfoPelicula.vue';
import AdminPage from './components/Vistas/AdminPage.vue'; 
import PaginaReservasUsuario from './components/Vistas/PaginaReservasUsuario.vue';
import PaginaPagoNologin from  './components/Vistas/PaginaPagoNologin.vue';


const routes: Array<RouteRecordRaw> = [
  { path: '/', name: 'HomePage', component: HomePage },
  { path: '/infopeli/:movieId', name: 'InfoPelicula', component: InfoPelicula },
  { path: '/PaginaReserva/:sesionID', name: 'PaginaReserva', component: PaginaReserva },
  { path: '/pagina-pago', name: 'PaginaPago', component: PaginaPago },
  { path: '/Auth', name: 'PaginaLogin', component: PaginaLogin },
  { path: '/UsuarioReservas', name: 'UsuarioReservas', component: PaginaReservasUsuario },
  { path: '/admin', name: 'AdminPage', component: AdminPage, meta: { necesarioAdmin: true } },
  { path: '/PaginaPagoNoLogin', name: 'PaginaPagoNologin', component: PaginaPagoNologin },
  
];


const router = createRouter({
  history: createWebHistory(),
  routes,
});


router.beforeEach((to, from, next) => {
  const store = useUsuariosStore();
  const necesarioAdmin = to.matched.some(record => record.meta.necesarioAdmin);

  if (necesarioAdmin && (!store.logueado || store.currentUser.rol !== 1)) {
    next({ name: 'HomePage' });
  } else {
    next();
  }
});

export default router;