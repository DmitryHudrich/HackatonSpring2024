<script setup>
import RoutesList from '@/components/RoutesList/RoutesList.vue'
</script>

<template>
  <div class="page">
    <p class="title">Мои маршруты</p>
    <RoutesList />
  </div>
</template>

<style scoped>
.title {
  font-size: 24px;
  font-weight: 700;
  margin-bottom: 40px;
}
</style>
