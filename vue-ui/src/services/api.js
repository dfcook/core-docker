import axios from 'axios'

export const getTodos = async () => axios.get('/api/Todo')
