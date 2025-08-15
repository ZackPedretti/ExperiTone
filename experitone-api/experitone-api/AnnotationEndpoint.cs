using experitone_api.Entities;

namespace experitone_api;

public static class AnnotationEndpoint
{
    public static void MapAnnotationEndpoint(this WebApplication app, ISearchEngineHandler searchEngine)
    {
        app.MapPut("/annotation", (Annotation annotation) =>
            {
                var annotationId = Guid.NewGuid();
                var updatedAnnotation = annotation with
                {
                    Details = annotation.Details with { AnnotationId = annotationId, CreatedAt = DateTime.UtcNow, Votes = 0}
                };
                try
                {
                    searchEngine.PutAnnotation(updatedAnnotation);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                return updatedAnnotation;
            })
            .WithName("PutAnnotation");
        
        app.MapGet("/annotation", (Guid annotationId) =>
            {
                try
                {
                    return searchEngine.GetAnnotation(annotationId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            })
            .WithName("GetAnnotation");
        
        app.MapGet("/annotations_of_song", (string videoId, int? offset, int? limit) =>
            {
                
            })
            .WithName("GetAnnotationsOfSong");
        
        app.MapGet("/recent", (int? offset, int? limit) =>
            {
                
            })
            .WithName("GetRecentlyAnnotatedSongs");
        
        app.MapGet("/most_annotated", (int? offset, int? limit) =>
            {
                
            })
            .WithName("GetMostAnnotatedSongs");
    }
}