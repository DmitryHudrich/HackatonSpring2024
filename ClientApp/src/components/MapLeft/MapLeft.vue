<script setup>
import Filter from '../Filter/Filter.vue'
import RouteAndFriend from '../RouteAndFriend/RouteAndFriend.vue'
</script>

<template>
  <div class="map-left">
    <Filter />
    <RouteAndFriend />
  </div>
</template>

<style scoped>
.map-left {
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-direction: column;
  max-width: 514px;
  max-height: 972px;
  gap: 1em;
  height: 100%;
  margin-right: 10px;
}
</style>
