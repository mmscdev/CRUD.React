import axios from 'axios';

export default axios.create({
    baseURL: 'https://localhost:49155/api'
})