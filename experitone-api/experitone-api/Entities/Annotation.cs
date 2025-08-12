namespace experitone_api.Entities;

public record Annotation(string Id, string Title, string Author, string Description, int Duration, AnnotationDetails Details);