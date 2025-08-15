using experitone_api.Entities;

namespace experitone_api;

public interface ISearchEngineHandler
{
    void PutAnnotation(Annotation annotation);
    Annotation? GetAnnotation(Guid annotationId);
    Annotation[]? GetAnnotationsOfSong(string songId, int? offset, int? limit);
    Song[]? GetRecentlyAnnotatedSongs(int? offset, int? limit);
    Song[]? GetMostAnnotatedSongs(int? offset, int? limit);
    void DeleteAnnotation(Annotation annotation);
}