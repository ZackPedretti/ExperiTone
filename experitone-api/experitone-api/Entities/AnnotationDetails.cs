namespace experitone_api.Entities;

public record AnnotationDetails(Guid? AnnotationId, int StartTimestamp, int? EndTimestamp, string Title, string Description, string AuthorId, DateTime? CreatedAt, int? Votes);