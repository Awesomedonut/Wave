import apiClient from './apiClient';
import Cookies from 'js-cookie';

interface LoginResponse {
  token: string;
  // Add other response fields as needed
}

export async function login(username: string, password: string): Promise<LoginResponse> {
  try {
    const response = await apiClient.post<LoginResponse>('/api/account/login', {
      username,
      password,
    });

    // Assuming the response contains the token
    const { token } = response.data;
    Cookies.set('auth_token', token, { expires: 7, path: '/' }); // Store token in a cookie

    return response.data;
  } catch (error) {
    console.error('Login error:', error);
    throw error;
  }
}

export function logout(): void {
  Cookies.remove('auth_token'); // Remove the token from cookies
}
