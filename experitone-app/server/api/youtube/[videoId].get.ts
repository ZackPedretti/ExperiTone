import { Song } from "~~/entities/Song";

export default defineEventHandler(async (event) => {
    const videoId = event.context.params?.videoId

    if (!videoId) {
        return null;
    }

    const response = await fetch(`https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics,contentDetails&id=${videoId}&key=${process.env.YOUTUBE_API_KEY}`);
    const data = await response.json()
    console.log(data)
    const song: Song = {
        videoId,
        title: data.items[0].snippet.title as string,
        author: data.items[0].snippet.channelTitle as string,
        description: data.items[0].snippet.description as string,
        duration: iso8601ToSeconds(data.items[0].contentDetails.duration),
        annotationCount: 0,
        lastUpdated: (new Date()).toISOString(),
    }
    return song
})

function iso8601ToSeconds(iso: string): number {
    const match = iso.match(/PT(?:(\d+)H)?(?:(\d+)M)?(?:(\d+)S)?/);
    if (!match) return 0;
    const hours = parseInt(match[1] || "0", 10);
    const minutes = parseInt(match[2] || "0", 10);
    const seconds = parseInt(match[3] || "0", 10);
    return hours * 3600 + minutes * 60 + seconds;
}