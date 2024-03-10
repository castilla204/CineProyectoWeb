import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import { useUsuariosStore } from './store/UsuarioStore'; 


import HomePage from './components/Homepage.vue';
import PaginaReserva from './components/PaginaReserva.vue';
import PaginaPago from './components/PaginaPago.vue';
import PaginaLogin from './components/PaginaLogin.vue';
import InfoPelicula from './components/InfoPelicula.vue';
import AdminPage from './components/AdminPage.vue'; 


const routes: Array<RouteRecordRaw> = [
  { path: '/', name: 'HomePage', component: HomePage },
  { path: '/infopeli/:movieId', name: 'InfoPelicula', component: InfoPelicula },
  { path: '/PaginaReserva/:sesionID', name: 'PaginaReserva', component: PaginaReserva },
  { path: '/pagina-pago', name: 'PaginaPago', component: PaginaPago },
  { path: '/Auth', name: 'PaginaLogin', component: PaginaLogin },
  { path: '/admin', name: 'AdminPage', component: AdminPage, meta: { necesarioAdmin: true } },
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