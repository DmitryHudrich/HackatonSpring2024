<script setup lang>
import { NavigationMenu, NavigationMenuList } from '@/components/ui/navigation-menu'
import HeaderNavigationItem from './HeaderNavigationItem.vue'
</script>

<template>
  <NavigationMenu>
    <NavigationMenuList>
      <HeaderNavigationItem link="/" name="Главная" />
      <HeaderNavigationItem link="/map" name="Карта" />
      <HeaderNavigationItem link="/routes" name="Маршруты" />
      <HeaderNavigationItem link="/friends" name="Друзья" />
    </NavigationMenuList>
  </NavigationMenu>
</template>
