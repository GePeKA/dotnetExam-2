import axios from 'axios';

export const axiosToBackend = axios.create({
    //TODO: Добавить baseURL к бэку
    baseURL: ``,
    withCredentials: true,
    timeout: 30000
});

axiosToBackend.interceptors.request.use((config) => {
    config.headers.Authorization = `Bearer ${localStorage.getItem('token')}`;
    return config;
})