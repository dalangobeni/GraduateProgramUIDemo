import axios from 'axios';

const BASE_URL = 'https://localhost:44309/api';

export const fetchAllStudentsApi = () =>
  axios
    .get(`${BASE_URL}/Students`)
    .then(response => response)
    .catch(error => error.response);
