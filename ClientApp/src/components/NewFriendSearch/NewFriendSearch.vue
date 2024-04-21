<template>
  <div class="block">
    <div class="search">  
      <img src="@/assets/image/main/search.png" alt="">
      <Input placeholder="Введите имя пользователя"/>
    </div>
    <FriendList/>
  </div>
</template>

<script setup>
import Input from '../ui/input/Input.vue';
import FriendList from '../FriendList/FriendList.vue';
</script>

<style scoped>

</style>