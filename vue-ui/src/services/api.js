import axios from 'axios'

const http = axios.create({
  timeout: 10000,
  withCredentials: true
})

export const getTodos = async () => {
  const response = await http.get('/api/Todo')
  return response.data
}

export const createTodo = async (todo) => {
  const response = await http.post(`/api/Todo`, todo)
  return response.data
}

export const updateTodo = async (todo) => http.put(`/api/Todo/${todo.id}`, todo)
export const deleteTodo = async (todo) => http.delete(`/api/Todo/${todo.id}`)
