import type { Player } from '@vue-youtube/component'

export const useYoutubePlayerStore = defineStore('youtube-player', () => {
  const player = ref<Player | null>(null)

  return { player }
})
