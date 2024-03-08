import { createRouter, createWebHistory } from 'vue-router';
import type { RouteRecordRaw } from 'vue-router';
import HomePage from './components/Homepage.vue';
import InfoPelicula from './components/InfoPelicula.vue';
import Butacas from './components/Butacas.vue';


const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage
  },
  {
    path: '/infopeli:movieId',
    name: 'InfoPelicula',
    component: InfoPelicula,
  },
  { 
    path:'/Butacas',
    name: 'Butacas',
    component:Butacas,
  },

];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;