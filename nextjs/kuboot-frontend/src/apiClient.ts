import axios, { InternalAxiosRequestConfig } from 'axios';
import Cookies from 'js-cookie';

// Create an Axios instance
const apiClient = axios.create({
  baseURL: process.env.NEXT_PUBLIC_ABP_API_BASE_URL, // Use environment variable for the API base URL
  withCredentials: true, // Ensure cookies are sent with requests
});

// Add a request interceptor to attach the token
apiClient.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    const token = Cookies.get('auth_token'); // Get the token from cookies
    if (token) {
      config.headers = {
        ...config.headers,
        Authorization: `Bearer ${token}`, // Attach token to the Authorization header
      } as InternalAxiosRequestConfig['headers']; // Ensure the correct type is used
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default apiClient;
