<script setup>
  import FriendList from '@/components/FriendList/FriendList.vue';
  import NewFriendSearch from '@/components/NewFriendSearch/NewFriendSearch.vue';
</script>

<template>
  <div class="page">
    <div class="my-friends">
      <p class="title">Мои друзья</p>
      <FriendList />
    </div>
    <NewFriendSearch/>
  </div>
</template>

<style scoped>
.page {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.title {
  font-size: 24px;
  font-weight: 700;
}

.my-friends {
  max-width: 677px;
  display: flex;
  flex-direction: column;
  gap: 80px;
}
</style>
