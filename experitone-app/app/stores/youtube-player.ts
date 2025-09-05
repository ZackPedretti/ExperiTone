export const useYoutubePlayerStore = defineStore('youtube-player', () => {
  const player = ref<YT.Player | null>(null)


  watch(player, () => {
    console.log(player.value)
  })

  return { player }
})