namespace experitone_api.Entities;

public record Comment(Guid Id, string Text, Guid AuthorId, DateTime CreatedAt, Guid AnnotationId);