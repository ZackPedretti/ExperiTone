import { Annotation } from "~/entities/Annotation";

export default defineEventHandler(async (event) => {
    const videoId = getQuery(event).videoId as string;
    return await $fetch<Annotation[]>(`http://experitone-api:2570/annotations_of_song?videoId=${videoId}`)
})
