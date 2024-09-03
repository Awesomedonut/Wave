import axios from 'axios';
import apiClient from './apiClient'; // Your configured Axios instance

export const fetchMessage = async (): Promise<string> => {
  try {
    const response = await apiClient.get('/api/test/message'); // Make a GET request to the .NET backend
    console.log(response);
    return response.data; // Return the message from the backend
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error('Axios error:', error.message);
      console.error('Response:', error.response);
      console.error('Request:', error.request);
    } else {
      console.error('Unexpected error:', error);
    }
    throw error;
  }
};
