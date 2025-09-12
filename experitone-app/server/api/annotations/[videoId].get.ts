import { ElasticAnnotation } from "~~/entities/ElasticAnnotation";
import {annotationFromElasticAnnotation} from "~~/entities/Annotation";

export default defineEventHandler(async (event) => {
    const videoId = event.context.params?.videoId
    return (await $fetch<ElasticAnnotation[]>(`http://experitone-api:2570/annotations_of_song?videoId=${videoId}`)).map((a: ElasticAnnotation) => annotationFromElasticAnnotation(a))
})
