<script setup>
import AbouOrganization from './AbouOrganization.vue';
import OrganizationImage from './OrganizationImage.vue';

</script>

<template>
    <div>
      <div class="map-bottom">
        <AbouOrganization />
        <OrganizationImage />
      </div>
    </div>
</template>
  
  
<style scoped>
.map-bottom {
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-direction: row;
  max-width: 1187px;
}
</style>