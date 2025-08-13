using experitone_api.Entities;

namespace experitone_api;

public static class AnnotationEndpoint
{
    public static void MapAnnotationEndpoint(this WebApplication app, ISearchEngineHandler searchEngine)
    {
        app.MapPut("/annotation", (Annotation annotation) =>
            {
                var updatedAnnotation = annotation with
                {
                    Details = annotation.Details with { CreatedAt = DateTime.UtcNow, Votes = 0}
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
    }
}