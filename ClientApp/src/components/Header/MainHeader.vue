<script setup>
import HeaderNavigation from './HeaderNavigation.vue'
import { useRouter } from 'vue-router';

const router = useRouter();
</script>
<template>
  <div class="header">
    <img src="@/assets/image/GroupGo.svg" alt="logo" @click="router.push('/')"/>
    <HeaderNavigation/>
    <div class="header__button_user" v-if="true">
      <router-link to = '/register'>
        <button class="header__button_user_button">Зарегестрироваться</button>
      </router-link>  
    </div>
    <div class="header__user_info" v-else>
      <router-link to = '/profile'>
        <div class="header__user_login"></div>
        <div class="header__user_photo"></div>
      </router-link>
    </div>
  </div> 
</template>

<style scoped>
.header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  margin-top: 30px;
  margin-bottom: 1em;
}

.header__button_user_button {
  background-image: var(--main-gradient);
  padding: 13px 44px;
  border-radius: 20px;
  font-size: 20px;
  font-weight: 700;
  color: #fff;
}

.header__user_info {
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 20px;
}

img {
  cursor: pointer;
  mix-blend-mode: difference;
}
</style>
