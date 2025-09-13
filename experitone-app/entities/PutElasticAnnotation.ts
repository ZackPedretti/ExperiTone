import type {Annotation} from "~~/entities/Annotation";

export type PutElasticAnnotation = {
    videoId: string;
    title: string;
    author: string;
    description: string;
    duration: number;
    details: {
        startTimestamp: number;
        endTimestamp: number | undefined;
        title: string;
        description: string | undefined;
        authorId: string;
    }
}