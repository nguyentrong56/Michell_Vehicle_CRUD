import Vue from 'vue'
import App from './App.vue'
import Router from "./router"
import Vuetify from "vuetify";
import "vuetify/dist/vuetify.min.css";
import Vuelidate from 'vuelidate';

Vue.config.productionTip = false
Vue.use(Vuetify,Vuelidate);



new Vue({
  router:Router,
  vuetify : new Vuetify(),
  render: h => h(App),
}).$mount('#app')

