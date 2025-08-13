namespace experitone_api.Entities;

public record Annotation(string VideoId, string Title, string Author, string Description, int Duration, AnnotationDetails Details);