import Vue from 'vue'
import Vuetify from 'vuetify'
import Vuex from 'vuex'

import App from './App.vue'
import createStore from './store'
import { login } from './services/auth';

Vue.config.productionTip = false

Vue.use(Vuetify)
Vue.use(Vuex)

const token = localStorage.getItem('user')
if (!token) {
  login()
}

new Vue({
  store: createStore(),
  render: h => h(App)
}).$mount('#app')
