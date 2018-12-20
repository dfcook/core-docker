import {
  ADD_TODO,
  DELETE_TODO,
  UPDATE_TODO,
  TODOS_LOADING,
  LOAD_TODOS,
  UPDATE_FILTER
} from './mutations'

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
  },
  async deleteTodo ({ commit }, todoId) {
    await api.deleteTodo(todoId)
    commit(DELETE_TODO, todoId)
  },
  async updateTodo ({ commit }, todo) {
    await api.updateTodo(todo)
    commit(UPDATE_TODO, todo)
  },
  updateFilter ({ commit }, filter) {
    commit(UPDATE_FILTER, filter)
  }
}