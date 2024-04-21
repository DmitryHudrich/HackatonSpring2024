<template>
  <div class="block">
    <div class="search">  
      <img src="@/assets/image/main/search.png" alt="">
      <Input placeholder="Введите имя пользователя"/>
    </div>
    <NewFriendList/>
  </div>
</template>

<script setup>
import Input from '../ui/input/Input.vue';
import NewFriendList from './NewFriendList.vue';
</script>

<style scoped>

</style>