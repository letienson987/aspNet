<template>
  <div>
    <input v-model="searchQuery" placeholder="Search film by ID...">
    <button @click="searchFilm">Search</button>

    <div v-if="searchResults">
      <h2>Search Result:</h2>
      <p><strong>Title:</strong> {{ searchResults.name }}</p>
      <p><strong>Description:</strong> {{ searchResults.description }}</p>
    </div>
  </div>
</template>

<script>
import filmApi from './api/filmApi.ts';

export default {
  data() {
    return {
      searchQuery: '',
      searchResults: null,
    };
  },
  methods: {
    async searchFilm() {
      try {
        const film = await filmApi.getFilmById(this.searchQuery); 
        this.searchResults = film;
      } catch (error) {
        console.error('Error searching film:', error);
        this.searchResults = null;
      }
    },
  },
};
</script>

<style>
/* ... styles ... */
</style>
