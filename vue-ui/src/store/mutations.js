export const LOAD_TODOS = 'LOAD_TODOS'
export const ADD_TODO = 'ADD_TODO'
export const TODOS_LOADING = 'TODOS_LOADING'

export default {
  [LOAD_TODOS] (state, todos) {
    state.todos = todos
  },
  [ADD_TODO] (state, todo) {
    state.todos = [ ...state.todos, todo ]
  },
  [TODOS_LOADING] (state, loading) {
    state.todosLoading = loading
  }
}
