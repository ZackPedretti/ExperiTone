namespace experitone_api.Entities;

public record User(string Id, string Name, DateTime CreatedAt, Guid[] AnnotationIds, int AnnotationCount, int VoteCount, UserLink[] Links);