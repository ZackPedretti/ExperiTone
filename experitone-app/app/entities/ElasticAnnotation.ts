import type {Annotation} from "~/entities/Annotation";

export type ElasticAnnotation = {
    videoId: string;
    title: string;
    author: string;
    description: string;
    duration: number;
    annotationCount: number;
    lastUpdated: string;
    details: Annotation;
}