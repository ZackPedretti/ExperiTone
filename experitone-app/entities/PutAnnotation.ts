export type PutAnnotation = {
    startTimestamp: number;
    endTimestamp: number | undefined;
    title: string;
    description: string | undefined;
}

export function newPutAnnotation(startTimestamp: number | undefined): PutAnnotation {
    return {
        startTimestamp: startTimestamp ?? 0,
        endTimestamp: undefined,
        title: "",
        description: "",
    }
}