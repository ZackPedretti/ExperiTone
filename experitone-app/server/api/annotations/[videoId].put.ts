import {auth} from "../../lib/auth";
import {Annotation} from "~~/entities/Annotation";
import {Song} from "~~/entities/Song";

export default defineEventHandler(async (event) => {
    const session = await auth.api.getSession(event);

    if (!session) {
        throw createError({
            statusCode: 401,
            statusMessage: "Unauthorized",
        });
    }

    const videoId = event.context.params?.videoId

    let song;
    const localSong = await $fetch<Song[]>(`/api/annotations/${videoId}`);
    if (!localSong || !localSong.length) {
        song = await $fetch<Song>(`/api/youtube/${videoId}`);
    }
    else {
        song = localSong[-1];
    }

    const body = {
        ...song,
        ...(await readBody<Annotation>(event)),
    } as Annotation;

    return await $fetch("http://experitone-api:2570/annotation", {
        method: "PUT",
        body,
    })
});