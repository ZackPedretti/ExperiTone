export const useYoutubeVideoStore = defineStore('youtube-video', () => {
  const videoId = ref('26gDUjMxgXw')
  const videoDuration = ref(0)

  return { videoId, videoDuration }
})
