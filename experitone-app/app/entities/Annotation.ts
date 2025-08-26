export type Annotation = {
    annotationId: string;
    startTimeStamp: number;
    endTimeStamp: number | null;
    title: string;
    description: string | null;
    authorId: string;
    createdAt: string;
    votes: number;
}
