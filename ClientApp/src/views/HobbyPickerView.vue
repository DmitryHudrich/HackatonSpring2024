<script setup>
import Input from '@/components/ui/input/Input.vue'
import Footer from '@/components/Footer/MainFooter.vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const back = () => {
  router.go(-1)
}
</script>

<template>
  <img src="@/assets/image/main/cross.png" alt="close" class="close" @click="back" />
  <div class="hobby__container">
    <div class="hobby__content">
      <div class="hobby__title">
        <h1>Укажите Ваши хобби</h1>
      </div>
      <div class="hobby__content_badges">
        <button>Тишина</button>
        <button>Вкусная еда</button>
        <button>Дешево</button>
        <button>Приятная музыка</button>
        <button>Круглосуточный</button>
        <button>Атмосфера</button>
        <button>Просторный зал</button>
        <button>Можно петь</button>
      </div>
      <router-link to="/map">
        <button class="hobby__button">Создать аккаунт</button>
      </router-link>  
    </div>   
  </div>
</template>

<style scoped>
h1 {
  margin-top: 120px;
  font-size: 32px;
  font-weight: 900;
}

.close {
  position: absolute;
  top: 50px;
  left: 150px;
  mix-blend-mode: difference;
}

.hobby__button {
  font-size: 32px;
  color: black;
  font-weight: 700;
  border: none;
  border-radius: 20px;
  padding: 6px 97px;
  background-image: var(--reg-button-gradient);
}

.hobby__content_badges {
  display: flex;
  flex-wrap: wrap;
  align-items: center;
  justify-content: center;
  gap: 80px;
}

button {
  border: none;
  background-image: var(--not-active-gradient);
  font-size: 24px;
  font-weight: 500;
  padding: 22px 65px;
  color: white;
  border-radius: 20px;
}

.hobby__content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 120px;
}

</style>
