<template>
  <div class="item">
    <div class="info">
      <img src="" alt="аватарка" class="avatar" />
      <div class="text">
        <p class="name">имя</p>
        <p class="hobbies">Общих хобби</p>
      </div>
    </div>
    <div class="add">
      <img src="@/assets/image/main/add.png" alt="addFriend" @click="addFriend" />
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  user: {
    type: Object,
    default: ''
  }
})
const addFriend = () => {}
</script>

<style scoped>
.add {
  mix-blend-mode: difference;
}
</style>
