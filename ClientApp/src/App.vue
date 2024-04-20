<script setup>
// import { RouterLink, RouterView } from 'vue-router'
import {onMounted} from "vue";
import Button from "@/components/ui/button/Button.vue";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle, }
from '@/components/ui/card'

onMounted(async () => {
  await fetch("https://jsonplaceholder.typicode.com/todos/1")
    .then(response => response.json())
    .then(json => console.log(json))
})
</script>

<template>
  <Card>
    <CardHeader>
      <CardTitle>Card title</CardTitle>
      <CardDescription>Card description</CardDescription>
    </CardHeader>
    <CardContent>
      <p>Card content</p>
    </CardContent>
  </Card>
  <Button>VLivke</Button>
  asdfgsfhgjkhjassdfkuylkjhgdfghjfkgjhgfbnfhytsdcvnhfvnmgfcjrgjfjvjfhgfh
<!--  <RouterView />-->
  <Card></Card>
</template>

<style scoped>
</style>
