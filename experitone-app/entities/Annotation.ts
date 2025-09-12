import type {ElasticAnnotation} from "~~/entities/ElasticAnnotation";

export type Annotation = {
    annotationId: string | undefined;
    startTimestamp: number;
    endTimestamp: number | null;
    title: string;
    description: string | undefined;
    authorId: string | undefined;
    createdAt: string;
    votes: number | undefined;
}

export function annotationFromElasticAnnotation(ea: ElasticAnnotation): Annotation {
    return ea.details;
}