import type { PlayerError } from '@vue-youtube/component'

export enum PlayerState {
  LOADING = 'loading',
  LOADED = 'loaded',
  ERROR = 'error',
}

export const useYouTubePlayerStatusStore = defineStore('youtube-player-status', () => {
  const playerState = ref<PlayerState>(PlayerState.LOADING)
  const error: Ref<PlayerError | null> = ref(null)

  return { playerState, error }
})
