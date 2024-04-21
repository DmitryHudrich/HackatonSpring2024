<template>
  <div class="block" v-if="friends">
    <div class="list" v-for="friend in friends" :key="friend.id">
      <NewFriendListItem  />
    </div>
  </div>
</template>

<script setup>
import NewFriendListItem from './NewFriendListItem.vue';
// const friends = ref([]);
</script>

<style scoped>
.block {
  display: flex;
  flex-direction: column;
  max-width: 677px;
  gap: 40px; 
}
</style>