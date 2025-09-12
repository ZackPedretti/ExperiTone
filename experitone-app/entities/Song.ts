import type {ElasticAnnotation} from "~~/entities/ElasticAnnotation";

export type Song = {
    videoId: string;
    title: string;
    author: string;
    description: string;
    duration: number;
    annotationCount: number;
    lastUpdated: string;
}

export function songFromElasticAnnotation(ea: ElasticAnnotation): Song {
    return {
        videoId: ea.videoId,
        title: ea.title,
        author: ea.author,
        description: ea.description,
        duration: ea.duration,
        annotationCount: ea.annotationCount,
        lastUpdated: ea.lastUpdated,
    }
}