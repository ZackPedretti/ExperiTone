namespace experitone_api.Entities;

public record AnnotationDetails(int StartTimestamp, int? EndTimestamp, string Title, string Description, string AuthorId);