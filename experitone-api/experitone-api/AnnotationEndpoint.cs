using experitone_api.Entities;

namespace experitone_api;

public static class AnnotationEndpoint
{
    public static void MapAnnotationEndpoint(this WebApplication app, ISearchEngineHandler searchEngine)
    {
        app.MapPut("/annotation", (Annotation annotation) =>
            {
                try
                {
                    searchEngine.PutAnnotation(annotation);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

                return annotation;
            })
            .WithName("PutAnnotation");
    }
}