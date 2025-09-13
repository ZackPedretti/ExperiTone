import type {ElasticAnnotation} from "~~/entities/ElasticAnnotation";
import assert from "node:assert";

export type Annotation = {
    annotationId: string;
    startTimestamp: number;
    endTimestamp: number | null;
    title: string;
    description: string | undefined;
    authorId: string;
    createdAt: string;
    votes: number;
}

export function annotationFromElasticAnnotation(ea: ElasticAnnotation): Annotation {
    return ea.details;
}