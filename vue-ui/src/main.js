import Vue from 'vue'
import Vuetify from 'vuetify'
import Vuex from 'vuex'

import App from './App.vue'
import createStore from './store'

Vue.config.productionTip = false

Vue.use(Vuetify)
Vue.use(Vuex)

new Vue({
  store: createStore(),
  render: h => h(App)
}).$mount('#app')
