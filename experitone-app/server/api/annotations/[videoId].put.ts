import {auth} from "../../lib/auth";
import {PutAnnotation} from "~~/entities/PutAnnotation";
import {Song} from "~~/entities/Song";
import {ElasticAnnotation} from "~~/entities/ElasticAnnotation";
import {PutElasticAnnotation} from "~~/entities/PutElasticAnnotation";

export default defineEventHandler(async (event) => {
    const session = await auth.api.getSession(event);

    if (!session) {
        throw createError({
            statusCode: 401,
            statusMessage: "Unauthorized",
        });
    }

    const videoId = event.context.params?.videoId

    const song = await $fetch<Song>(`/api/song/${videoId}`);

    const body: PutElasticAnnotation = {
        ...song,
        details: {
            ...(await readBody<PutAnnotation>(event)),
            authorId: session.user.id,
        }
    };

    console.log(body);

    return await $fetch("http://experitone-api:2570/annotation", {
        method: "PUT",
        body,
    })
});