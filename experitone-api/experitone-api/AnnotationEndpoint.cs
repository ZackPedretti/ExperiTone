using experitone_api.Entities;

namespace experitone_api;

public static class AnnotationEndpoint
{
    public static void MapAnnotationEndpoint(this WebApplication app, ISearchEngineHandler searchEngine)
    {
        app.MapPut("/annotation", (Annotation annotation) =>
            {
                return annotation;
            })
            .WithName("PutAnnotation");
    }
}