<script setup>
import AboutOrganization from '@/components/AboutOrganization/AboutOrganization.vue'
import OrganizationImage from '@/components/OrganizationImage/OrganizationImage.vue'
</script>

<template>
  <div>
    <div class="map-bottom">
      <AboutOrganization class="about" />
      <OrganizationImage class="image" />
    </div>
  </div>
</template>

<style scoped>
.map-bottom {
  display: flex;
  justify-content: stretch;
  align-items: center;
  flex-direction: row;
  max-width: 1187px;
  margin-top: 10px;
  gap: 10px;
}
.about {
  flex-grow: 1;
}
.image {
  height: 100%;
}
</style>
