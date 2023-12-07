import axios from 'axios';

const API_BASE_URL = 'https://localhost:7022/api';

interface Film {
  id: number;
  Title: string;
  Description: string;
  Author: string;
  Category: number;
}

const filmApi = {
  fetchData: async (url: string) => {
    try {
      const response = await axios.get(url);
      return response.data;
    } catch (error) {
      throw new Error(`Error fetching data: ${error}`);
    }
  },

  getFilm: async (): Promise<Film[]> => {
    return filmApi.fetchData(`${API_BASE_URL}/films`);
  },

  getFilmById: async (id: number): Promise<Film> => {
    return filmApi.fetchData(`${API_BASE_URL}/films/${id}`);
  },

  deleteFilmById: async (id: number): Promise<Film> => {
    return filmApi.fetchData(`${API_BASE_URL}/films/${id}`);
  },

  updateFilm: async (id: number, updatedFilm: Film): Promise<Film> => {
    try {
      const response = await axios.put(`${API_BASE_URL}/films/${id}`, updatedFilm);
      return response.data;
    } catch (error) {
      throw new Error(`Error updating film with ID ${id}: ${error}`);
    }
  },

};

export default filmApi;
