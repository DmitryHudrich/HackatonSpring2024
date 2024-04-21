<template>
  <div>
    <div v-if="routesList || routesList.length > 0">
      <div class="list" v-for="route in routesList" :key="route.id"></div>
    </div>
    <div v-else>
      <p>No Routes Found</p>
    </div>
  </div>
</template>

<script setup>
import RouterListItemVue from "./RouterListItem.vue";
const routesList = ref([]);
</script>

<style scoped>

</style>