import apiClient from './apiClient'; // Your configured Axios instance

export const fetchMessage = async (): Promise<string> => {
  try {
    const response = await apiClient.get('/api/test/message'); // Make a GET request to the .NET backend
    console.log(response);
    return response.data; // Return the message from the backend
  } catch (error) {
    console.error('Error fetching message:', error);
    throw error;

  }
};
