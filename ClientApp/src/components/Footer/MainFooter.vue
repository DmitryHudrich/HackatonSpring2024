<script setup></script>

<template>
  <div class="footer">
    <p class="logo">© GroupGo 2024</p>
    <div class="info">
      <p class="phone">+7 (988) 516-27-43</p>
      <div class="media">
        <a href="https://t.me/wtf2004android" target="_blank"
          ><img src="../../assets/image/main/Telegram.png" alt="tg"
        /></a>
        <a href="https://www.facebook.com/groupgo.ru/" target="_blank"
          ><img src="../../assets/image/main/VK.png" alt="vk"
        /></a>
        <a href="https://www.youtube.com/channel/UCa715n973-8t10l5-9_R60g" target="_blank"
          ><img src="../../assets/image/main/WhatsApp.png" alt="whatsapp"
        /></a>
        <a href="https://www.tiktok.com/@groupgo.ru" target="_blank"
          ><img src="../../assets/image/main/GitHub.png" alt="github"
        /></a>
      </div>
    </div>
  </div>
</template>

<style scoped>
.footer {
  display: flex;
  justify-content: space-between;
  border-top: 1px solid hsl(var(--primary));
  padding-block: 1em;
  margin-top: 120px;
}
.logo {
  font-size: 24px;
  font-weight: 600;
}
.info {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  gap: 1em;
}
.media {
  display: flex;
  gap: 10px;
}
</style>
