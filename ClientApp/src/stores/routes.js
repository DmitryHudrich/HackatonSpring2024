import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useRoutesStore = defineStore('routes', () => {
  const routes = ref({})

  return { user: routes }
})
