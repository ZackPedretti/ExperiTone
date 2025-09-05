export type Annotation = {
    annotationId: string;
    startTimestamp: number;
    endTimestamp: number | null;
    title: string;
    description: string | null;
    authorId: string;
    createdAt: string;
    votes: number;
}
