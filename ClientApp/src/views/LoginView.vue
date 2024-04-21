<script setup>
import Input from '@/components/ui/input/Input.vue'
import { useRouter } from 'vue-router'

const router = useRouter()

const back = () => {
  router.go(-1)
}
</script>

<template>
  <img src="@/assets/image/main/cross.png" alt="close" class="close" @click="back" />
  <div class="login__container">
    <div class="login__content">
      <div class="login__text">
        <h1>Войдите в аккаунт</h1>
      </div>
      <div class="login__form">
        <Input type="text" placeholder="Логин" />
        <Input type="password" placeholder="Пароль" />
      </div>
      <div class="login__button">
        <router-link to="/map">
          <button>Войти</button>
        </router-link>
        <div class="login__text_button">
          <p>ИЛИ</p>
        </div>
        <router-link to="/register">
          <button>Создать аккаунт</button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<style scoped>
.close {
  position: absolute;
  top: 50px;
  left: 150px;
  mix-blend-mode: difference;
}
p {
  font-weight: 300;
  font-size: 24px;
}

.login__text_button p {
  font-weight: 300;
  font-size: 24px;
  position: relative;
}

.login__text_button::before,
.login__text_button::after {
  content: '';
  height: 15px;
  width: 100px;
  scale: 10;
  background: hsl(var(--primary));
}

.login__container {
  gap: 80px;
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  z-index: 999;
  margin-top: 120px;
}

Input::placeholder {
  border: #5b5c5e;
  /* color: var(--primary-text-color); */
}

Input:focus {
  outline: none;
}

button {
  font-size: 32px;
  color: black;
  font-weight: 700;
  border: none;
  border-radius: 20px;
  padding: 6px 97px;
  background-image: var(--reg-button-gradient);
}

.login__content {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 80px;
}

.login__form {
  display: flex;
  flex-direction: column;
  gap: 40px;
}

h1 {
  font-weight: 900;
  font-size: 32px;
}

.login__button {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 40px;
}
</style>
