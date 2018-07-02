import axios from 'axios'

export const getValues = async () => axios.get('/api/Values')
