<template>
  <div class="youtube-player">
    <YoutubePlayer />
  </div>
</template>

<script lang="ts" setup>
  import YoutubePlayer from '@/components/YoutubePlayer.vue'
</script>

<style scoped lang="scss">
.youtube-player {
  position: absolute;
  bottom: 0;
  right: 0;
}
</style>
