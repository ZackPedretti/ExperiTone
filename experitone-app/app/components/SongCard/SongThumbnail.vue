<script setup lang="ts">
const props = defineProps<{
  videoId: string
}>()

const thumbnailURL = `https://img.youtube.com/vi/${props.videoId}/maxresdefault.jpg`
</script>

<template>
  <v-img
      :src="thumbnailURL"
      width="100%"
      max-width="500px"
      min-width="200px"
      aspect-ratio="16/9"
      class="rounded-lg"
  >

  <template #placeholder>
      <v-skeleton-loader
          type="image"
          width="100%"
          max-width="500px"
          min-width="200px"
          aspect-ratio="16/9"/>
    </template>
  </v-img>
</template>

<style scoped>

</style>