import './assets/main.css'
import {messages} from './language/language'; 
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createPinia } from 'pinia'
import { createI18n } from 'vue-i18n';

const i18n = createI18n({
  legacy: false, 
  locale: 'es', 
  fallbackLocale: 'en', 
  messages, 
});

const app = createApp(App)
const pinia = createPinia()

// Utilizar pini y router en vue
app.use(pinia)
app.use(router)
app.use(i18n); 

app.mount('#app')