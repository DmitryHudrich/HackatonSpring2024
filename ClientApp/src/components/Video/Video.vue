<script setup></script>

<template>
  <div class="image__container">
    <img src="@/assets/image/popka.svg" alt="popa" />
    <div class="video__block">
      <a>Собирайте свою компанию, наслаждайтесь моментом, а мы позаботимся об остальном.</a>
    </div>
  </div>
</template>

<style scoped>
.image__container {
  position: relative;
  width: 100%;
  max-width: 1760px;
  max-height: 848px;
}

img {
  width: 100%;
  height: 100%;
  border-radius: 20px;
}

.video__block {
  background-color: var(--background);
  max-width: 514px;
  max-height: 294px;
  padding: 30px 40px 30px 0px;
  position: absolute;
  bottom: 76px;
  border-radius: 0 20px 20px 0;
}

a {
  color: transparent;
  background-image: var(--main-gradient);
  -webkit-background-clip: text;
  background-clip: text;
  font-size: 32px;
  font-weight: 700;
}
</style>
