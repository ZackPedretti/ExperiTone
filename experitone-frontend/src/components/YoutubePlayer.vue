<script setup lang="ts">
  import type { ErrorEvent, Player, PlayerEvent } from '@vue-youtube/component'
  import { usePlayer } from '@vue-youtube/core'
  import { ref } from 'vue'
  import { PlayerState, useYouTubePlayerStatusStore } from '@/stores/youtube-player-status.ts'
  import { useYoutubePlayerStore } from '@/stores/youtube-player.ts'
  import { useYoutubeVideoStore } from '@/stores/youtube-video.ts'

  const { videoId } = storeToRefs(useYoutubeVideoStore())
  const { player } = storeToRefs(useYoutubePlayerStore())
  const { playerState, error } = storeToRefs(useYouTubePlayerStatusStore())
  playerState.value = PlayerState.LOADING
  const youtube = ref()

  const { onReady, onError } = usePlayer(videoId, youtube, {
    cookie: false,
    playerVars: {},
    width: 640,
    height: 390,
  })

  onReady((event: PlayerEvent) => {
    playerState.value = PlayerState.LOADED
    player.value = event.target as Player
    player.value.playVideo()
  })

  onError((event: ErrorEvent) => {
    playerState.value = PlayerState.ERROR
    error.value = event.data
  })

  watch(playerState, () => {
    console.log(playerState.value)
  })
</script>

<template>
  <div ref="youtube" />
</template>
