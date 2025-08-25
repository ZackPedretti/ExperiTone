<script setup lang="ts">
  const { t } = useI18n()
</script>

<template>
  <v-text-field
      class="ma-2 search-bar"
      density="comfortable"
      :placeholder="t('layout.searchbar.placeholder')"
      type="text"
      hide-details
      append-inner-icon="mdi-magnify"
      @click:append-inner=""
      rounded="lg"
      style="font-size: 1.1rem;"
      variant="outlined"
  ></v-text-field>
</template>

<style scoped>
.search-bar {
  position: absolute;
  left: 50%;
  transform: translateX(-50%);
  max-width: 600px;
  width: 100%;
}
</style>