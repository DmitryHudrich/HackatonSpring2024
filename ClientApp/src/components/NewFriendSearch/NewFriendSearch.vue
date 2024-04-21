<template>
  <div class="block">
    <div class="search">
      <Input placeholder="Введите имя пользователя" />
      <img src="@/assets/image/main/search.png" alt="" class="icon" />
    </div>
    <NewFriendList />
  </div>
</template>

<script setup>
import Input from '../ui/input/Input.vue'
import NewFriendList from './NewFriendList.vue'
</script>

<style scoped>
.search {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 10px;
  border-radius: 10px;
  margin-bottom: 20px;
}
.icon {
  height: 40px;
  aspect-ratio: 1;
  mix-blend-mode: difference;
}
</style>
