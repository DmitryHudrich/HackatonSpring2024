<template>
  <div class="block" v-if="friends">
    <div class="list" v-for="friend in friends" :key="friend.id">
      <FriendListItem />
    </div>
  </div>
  <p v-else>У Вас нет друзей</p>
</template>

<script setup>
import FriendListItem from './FriendListItem.vue'
// const friends = ref([]);
</script>

<style scoped>
.block {
  display: flex;
  flex-direction: column;
  max-width: 677px;
  gap: 20px;
}
</style>
