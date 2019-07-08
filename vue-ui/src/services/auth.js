import axios from 'axios'

export const login = async () => {
  const response = await axios.post('http://localhost:53180/api/v1/Authorize')
  localStorage.setItem('user', response.data)
}