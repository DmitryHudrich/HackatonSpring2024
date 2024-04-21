<script setup>
import ReviewCard from '@/components/ReviewCard/ReviewCard.vue'
import Video from '@/components/Video/Video.vue'
</script>

<template>
  <div class="page">
    <Video />
    <div class="card-list">
      <ReviewCard class="review" />
      <ReviewCard class="review" />
      <ReviewCard class="review" />
    </div>
  </div>
</template>

<style scoped>
.card-list {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
.page {
  display: flex;
  flex-direction: column;
  gap: 1em;
}
</style>
