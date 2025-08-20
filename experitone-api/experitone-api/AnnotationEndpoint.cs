using experitone_api.Entities;

namespace experitone_api;

public static class AnnotationEndpoint
{
    //TODO: return real errors when exceptions are encountered
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
        
        app.MapDelete("/annotation", (Guid annotationId) =>
        {
            //TODO: Auth verification
            try
            {
                searchEngine.DeleteAnnotation(annotationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        })
        .WithName("DeleteAnnotation");
        
        app.MapGet("/annotations_of_song", (string videoId, int? offset, int? limit) =>
            {
                try
                {
                    return searchEngine.GetAnnotationsOfSong(videoId, offset, limit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return [];
                }
            })
            .WithName("GetAnnotationsOfSong");
        
        app.MapGet("/song", (string query, int? offset, int? limit) =>
            {
                try
                {
                    return searchEngine.SearchSong(query, offset, limit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return [];
                }
            })
            .WithName("SearchSong");
        
        app.MapGet("/recent", (int? offset, int? limit) =>
            {
                try
                {
                    return searchEngine.GetRecentlyAnnotatedSongs(offset, limit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return [];
                }
            })
            .WithName("GetRecentlyAnnotatedSongs");
        
        app.MapGet("/most_annotated", (int? offset, int? limit) =>
            {
                try
                {
                    return searchEngine.GetMostAnnotatedSongs(offset, limit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return [];
                }
            })
            .WithName("GetMostAnnotatedSongs");
    }
}