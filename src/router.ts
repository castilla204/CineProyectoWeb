import { createRouter, createWebHistory } from 'vue-router';
import type { RouteRecordRaw } from 'vue-router';
//import PaginaPago from './components/PaginaPago.vue'; al añadir mas componentes se muestra mal el homepage
import HomePage from './components/Homepage.vue';


const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage
  },

];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;