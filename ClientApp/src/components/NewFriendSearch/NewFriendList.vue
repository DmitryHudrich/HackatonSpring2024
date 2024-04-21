<template>
  <div class="block" v-if="users">
    <div class="list" v-for="user in users" :key="user.id">
      <NewFriendListItem />
    </div>
  </div>
</template>

<script setup>
import NewFriendListItem from './NewFriendListItem.vue'
// const users = ref([]);
</script>

<style scoped>
.block {
  display: flex;
  flex-direction: column;
  max-width: 677px;
  gap: 40px;
}
</style>
