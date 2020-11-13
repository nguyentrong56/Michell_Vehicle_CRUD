import Vue from 'vue'
import App from './App.vue'
import Router from "./router"
import Vuetify from "vuetify";
import "vuetify/dist/vuetify.min.css";
import Vuelidate from 'vuelidate';
import Vuex from 'vuex'
import store from './store/store'
import VueProgressbar from'vue-progressbar'
Vue.config.productionTip = false
Vue.use(Vuetify,Vuelidate,Vuex);

const options = {
  color: '#00FF00',
  failedColor: '#FF0000',
  thickness: '5px',
  transition: {
    speed: '0.2s',
    opacity: '0.6s',
    termination: 300
  },
  autoRevert: true,
  location: 'top',
  inverse: false
}

Vue.use(VueProgressbar, options)

new Vue({
  store,
  router:Router,
  vuetify : new Vuetify(),
  render: h => h(App),
}).$mount('#app')

