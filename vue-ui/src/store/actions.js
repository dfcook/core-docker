import { ADD_TODO, TODOS_LOADING, LOAD_TODOS } from './mutations'

import * as api from '../services/api'

export default {
  async addTodo ({ commit }, thingToDo) {
    const todo = await api.createTodo({ text: thingToDo })
    commit(ADD_TODO, todo)
  },
  async loadTodos ({ commit }) {
    commit(TODOS_LOADING, true)
    const todos = await api.getTodos()
    commit(LOAD_TODOS, todos)
    commit(TODOS_LOADING, false)
  }
}