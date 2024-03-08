import { createRouter, createWebHistory } from 'vue-router';
import type { RouteRecordRaw } from 'vue-router';
import HomePage from './components/Homepage.vue';
import reservaButacas from './components/PaginaReserva.vue'
import PaginaPago from './components/PaginaPago.vue';
import PaginaLogin from './components/PaginaLogin.vue';
import InfoPelicula from './components/InfoPelicula.vue';
import PaginaReserva from './components/PaginaReserva.vue';


const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage
  },
  {
    path: '/infopeli/:movieId',
    name: 'InfoPelicula',
    component: InfoPelicula,
  },
  { 
    path:'/PaginaReserva/:sesionID',
    name: 'PaginaReserva',
    component:PaginaReserva,
  },
  {
    path: '/pagina-pago',
    name: 'PaginaPago',
    component: PaginaPago
  },
  {
    path: '/Auth',
    name: 'PaginaLogin',
    component: PaginaLogin
  },



];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
