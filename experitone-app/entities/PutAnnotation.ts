export type PutAnnotation = {
    startTimestamp: number;
    endTimestamp: number | undefined;
    title: string;
    description: string | undefined;
}