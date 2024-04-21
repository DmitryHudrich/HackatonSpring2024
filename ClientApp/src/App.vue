<script setup>
// import { RouterLink, RouterView } from 'vue-router'
import { onMounted, computed } from 'vue'
import Header from '@/components/Header/MainHeader.vue'
import Footer from '@/components/Footer/MainFooter.vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const currentRoute = computed(() => route.name)
const excludeRoutesList = ['login', 'register', 'hobby-picker']

function switchTheme() {
  document.getElementsByTagName('html')[0].classList.toggle('dark')
}

onMounted(async () => {
  await fetch('https://jsonplaceholder.typicode.com/todos/1')
    .then((response) => response.json())
    .then((json) => console.log(json))
})
</script>

<template>
  <div id="app">
    <div class="container">
      <button @click="switchTheme()">theme</button>
      <Header v-show="!excludeRoutesList.includes(currentRoute)" />
      <div class="content">
        <router-view></router-view>
      </div>
      <Footer  />
    </div>
  </div>
</template>

<style scoped>
#app {
  background-color: var(--background);
  display: flex;
  flex-direction: column;
  align-items: center;
  min-height: 100dvh;
}
.content {
  flex-grow: 1;
}
.container {
  margin-left: 80px;
  margin-right: 80px;
  min-height: 100dvh;
  display: flex;
  flex-direction: column;
}
</style>
