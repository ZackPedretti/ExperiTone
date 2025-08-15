namespace experitone_api.Entities;

public record AnnotationDetails(Guid? AnnotationId, int StartTimestamp, int? EndTimestamp, string Title, string Description, Guid AuthorId, DateTime? CreatedAt, int? Votes);