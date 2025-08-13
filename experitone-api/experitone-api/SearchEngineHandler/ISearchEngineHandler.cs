using experitone_api.Entities;

namespace experitone_api;

public interface ISearchEngineHandler
{
    void PutAnnotation(Annotation annotation);
    Annotation[]? GetAnnotations(string? query, int? offset, int? limit);
    void DeleteAnnotation(Annotation annotation);
}