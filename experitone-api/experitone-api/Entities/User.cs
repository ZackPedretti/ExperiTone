namespace experitone_api.Entities;

public record User(Guid Id, string Name, DateTime CreatedAt, Guid[] AnnotationIds, int AnnotationCount, int VoteCount, UserLink[] Links);