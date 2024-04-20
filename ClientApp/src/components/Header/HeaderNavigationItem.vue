<script setup>
import {
  NavigationMenuItem,
  NavigationMenuLink,
  navigationMenuTriggerStyle
} from '@/components/ui/navigation-menu'
import { RouterLink } from 'vue-router'
const props = defineProps({
  link: { type: String, required: true },
  name: { type: String, required: true }
})
</script>
<template>
  <div>
    <NavigationMenuItem>
      <router-link :to="props.link">
        <NavigationMenuLink :class="navigationMenuTriggerStyle()">
          {{ props.name }}
        </NavigationMenuLink>
      </router-link>
    </NavigationMenuItem>
  </div>
</template>

<style scoped></style>
