import {ElasticAnnotation} from "~~/entities/ElasticAnnotation";
import {Song, songFromElasticAnnotation} from "~~/entities/Song";

export default defineEventHandler(async (event) => {
    const videoId = event.context.params?.videoId
    const annotationsOfSong = await $fetch<ElasticAnnotation[]>(`http://experitone-api:2570/annotations_of_song?videoId=${videoId}`);
    if (!annotationsOfSong || annotationsOfSong.length === 0) {
        return $fetch<Song>(`/api/youtube/${videoId}`)
    }
    return songFromElasticAnnotation(annotationsOfSong[annotationsOfSong.length - 1]);
})