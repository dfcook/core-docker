import Vuex from 'vuex'

import actions from './actions'
import mutations from './mutations'

const createStore = () => new Vuex.Store({
  state: {
    todos: []
  },
  actions,
  mutations
})

export default createStore
