import axios from 'axios'

const createHttp = () => {
  const token = localStorage.getItem('user')
  const headers = token
    ? { 'Authorization': 'Bearer ' + token }
    : {}

  return axios.create({
    timeout: 10000,
    withCredentials: true,
    headers
  })
}

const baseUrl = 'http://localhost:61396/api/v1/Todo'

export const getTodos = async () => {
  const response = await createHttp().get(baseUrl)
  return response.data
}

export const createTodo = async (todo) => {
  const response = await createHttp().post(baseUrl, todo)
  return response.data
}

export const updateTodo = async (todo) => {
  const response = await createHttp().put(`${baseUrl}/${todo.id}`, todo)
  return response.data
}

export const deleteTodo = async (id) => await createHttp().delete(`${baseUrl}/${id}`)
