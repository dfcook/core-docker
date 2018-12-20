export const LOAD_TODOS = 'LOAD_TODOS'
export const ADD_TODO = 'ADD_TODO'
export const DELETE_TODO = 'DELETE_TODO'
export const TODOS_LOADING = 'TODOS_LOADING'
export const UPDATE_FILTER = 'UPDATE_FILTER'
export const UPDATE_TODO = 'UPDATE_TODO'

export default {
  [LOAD_TODOS] (state, todos) {
    state.todos = todos
  },
  [ADD_TODO] (state, todo) {
    state.todos = [ ...state.todos, todo ]
  },
  [DELETE_TODO] (state, id) {
    state.todos = state.todos.filter(t => t.id !== id)
  },
  [UPDATE_TODO] (state, todo) {
    state.todos = state.todos.map(t => t.id === todo.id ? todo : t)
  },
  [TODOS_LOADING] (state, loading) {
    state.todosLoading = loading
  },
  [UPDATE_FILTER] (state, filter) {
    state.filter = filter
  }
}
