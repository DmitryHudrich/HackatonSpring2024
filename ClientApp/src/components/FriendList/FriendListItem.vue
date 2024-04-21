<template>
  <div class="item">
    <div class="info">
      <img src="" alt="аватарка" class="avatar" />
      <p class="name">имя</p>
    </div>
    <div class="delete">
      <img src="@/assets/image/main/cross.png" alt="deleteFriend" @click="deleteFriend" />
    </div>
  </div>
</template>

<script setup>

const props = defineProps({
  friend: {
    type: Object,
    default: '',
  },
})
const deleteFriend = () => { }

</script>

<style scoped>
.name {
  font-size: 32px;
  font-weight: 400;
}

.avatar {
  border-radius: 50%;
  width: 80px;
  height: 80px;
}

.item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-direction: row;
}

.info {
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 10px;
}
</style>
