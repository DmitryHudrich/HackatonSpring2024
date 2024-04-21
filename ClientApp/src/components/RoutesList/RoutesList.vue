<template>
  <div>
    <div v-if="RoutesList">
      <div class="list" v-for="route in routesList" :key="route.id"></div>
    </div>
    <div v-else>
      <p>У Вас нет маршрутов</p>
    </div>
  </div>
</template>

<script setup>
import RoutesListItemVue from './RoutesListItem.vue'
// const routesList = ref([]);
</script>

<style scoped></style>
