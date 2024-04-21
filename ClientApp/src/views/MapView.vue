<script setup>
import YMap from '@/components/Map/YMap.vue'
import MapBottom from '@/components/MapBottom/MapBottom.vue'
import MapLeft from '@/components/MapLeft/MapLeft.vue'
</script>

<template>
  <div class="page">
    <div class="filters">
      <MapLeft />
    </div>
    <div class="other">
      <YMap />
      <MapBottom />
    </div>
  </div>
</template>

<style scoped>
.page {
  display: flex;
  justify-content: stretch;
  max-height: 70dvh;
}
.filters {
  max-width: 400px;
}
.other {
  flex-grow: 1;
}
</style>
