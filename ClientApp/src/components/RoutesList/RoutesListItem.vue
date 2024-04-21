<template>
  <div class="item">
    <div class="creation-info">
      <div class="user">
        <img src="" alt="" class="avatar" />
        <p class="username">username</p>
      </div>
      <p class="creation-date">creation date</p>
    </div>
    <div class="route-info">
      <p class="route-name">route name</p>
      <div class="tables">
        <div class="points" v-if="points">
          <div class="point" v-for="(point, index) in points" :key="point.id">
            <p class="point-name">{{ index + 1 }}. point name</p>
            <p class="point-time">time</p>
          </div>
        </div>
        <div class="friends" v-if="friends">
          <p class="friend" v-for="(friend, index) in friends" :key="friend.id">
            {{ index + 1 }}. friend
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { defineProps } from 'vue'

const props = defineProps({
  routeItem: {
    type: Object,
    default: ''
  }
})
</script>

<style scoped></style>
