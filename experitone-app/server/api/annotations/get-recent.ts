export default defineEventHandler(async () => {
    const records = await $fetch<{ id: number; text: string }[]>("http://experitone-api:2570/recent")

    return records.map(r => ({
        id: r.id,
        snippet: r.text.slice(0, 50) + "…"
    }))
})
