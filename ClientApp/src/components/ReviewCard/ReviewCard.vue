<template>
  <Card class="w-[30%]">
    <CardHeader>
      <img src="" alt="аватарка" class="image" />
    </CardHeader>
    <CardContent>
      <p>текст отзыва</p>
    </CardContent>
    <CardFooter>
      <div class="footer">
        <p class="username">username</p>
        <p class="login">login</p>
      </div>
    </CardFooter>
  </Card>
</template>

<script setup>
import { Card, CardHeader, CardContent, CardFooter } from '@/components/ui/card'
</script>
<style scoped>
.username {
  font-size: 20px;
}
.image {
  width: 90%;
  aspect-ratio: 16 / 12;
  border-radius: 12px;
  object-fit: cover;
}
</style>
