<template>
  <div class="youtube-player-wrapper">
    <div ref="playerContainer" class="youtube-player"></div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'

const { videoId } = defineProps<{ videoId: string }>()
const playerContainer = ref<HTMLDivElement>()
const { player } = storeToRefs(useYoutubePlayerStore())

onMounted(() => {
  if (!window.YT) {
    const tag = document.createElement('script')
    tag.src = 'https://www.youtube.com/iframe_api'
    document.body.appendChild(tag)
  }

  const interval = setInterval(() => {
    if (window.YT && window.YT.Player) {
      clearInterval(interval)
      player.value = new window.YT.Player(playerContainer.value!, {
        videoId,
        width: '100%',
        height: '100%',
        events: {
          onReady: (event: YT.PlayerEvent) => event.target.playVideo(),
          onError: (event: YT.ErrorEvent) => console.error('Player error', event.data)
        }
      })
    }
  }, 100)
})
</script>

<style scoped>
.youtube-player-wrapper {
  width: 50%;
  aspect-ratio: 16/9;
  z-index: 9999;
  border-radius: 8px;
  overflow: hidden;
  box-shadow: 0 4px 12px rgba(0,0,0,0.3);
}

.youtube-player {
  width: 100% !important;
  height: 100% !important;
}
</style>
