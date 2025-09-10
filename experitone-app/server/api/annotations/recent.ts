import {Song} from "~~/entities/Song";

export default defineEventHandler(async () => {
    return await $fetch<Song[]>("http://experitone-api:2570/recent")
})
