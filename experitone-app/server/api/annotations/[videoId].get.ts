import { ElasticAnnotation } from "~~/entities/ElasticAnnotation";

export default defineEventHandler(async (event) => {
    const videoId = event.context.params?.videoId
    return (await $fetch<ElasticAnnotation[]>(`http://experitone-api:2570/annotations_of_song?videoId=${videoId}`)).map((a: ElasticAnnotation) => a.details)
})
