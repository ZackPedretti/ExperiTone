using experitone_api.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
namespace experitone_api;

public class ElasticSearchHandler : ISearchEngineHandler
{
    private readonly ElasticsearchClient _client;
    private bool _ready = false;
    private const string IndexName = "annotations";

    private async Task InitializeIndex()
    {
        var existsResponse = await _client.Indices.ExistsAsync(IndexName);
        if (existsResponse.Exists)
            return;

        var createResponse = await _client.Indices.CreateAsync<Annotation>(index => index
            .Index(IndexName)
            .Mappings(mappings => mappings
                .Properties(properties => properties
                    .Text(x => x.VideoId)
                    .Text(x => x.Title)
                    .Text(x => x.Author)
                    .Text(x => x.Description)
                    .IntegerNumber(x => x.Duration)
                    .Object(o => o.Details, objConfig => objConfig
                        .Properties(p => p
                            .Keyword(x => x.Details.AnnotationId)
                            .IntegerNumber(x => x.Details.StartTimestamp)
                            .IntegerNumber(x => x.Details.EndTimestamp)
                            .Text(x => x.Details.Title)
                            .Text(x => x.Details.Description)
                            .Text(x => x.Details.AuthorId)
                            .Date(x => x.Details.CreatedAt)
                            .IntegerNumber(x => x.Details.Votes)
                        )
                    )
                )
            )
        );

        if (!createResponse.Acknowledged || !createResponse.IsValidResponse)
        {
            throw new Exception($"Error creating index: {createResponse.ElasticsearchServerError}");
        }

        _ready = true;
    }
    
    public ElasticSearchHandler(string url, string? apiKey)
    {
        var settings = new ElasticsearchClientSettings(new Uri(url));
        if (apiKey != null)
        {
            settings = settings.Authentication(new ApiKey(apiKey));
        }
        _client = new ElasticsearchClient(settings);
        InitializeIndex().GetAwaiter().GetResult();
    }

    public void PutAnnotation(Annotation annotation)
    {
        if (!_ready) return;
        
        var response = _client.IndexAsync(annotation, i => i
            .Index(IndexName)
            .Id(annotation.Details.AnnotationId)
        ).GetAwaiter().GetResult();

        if (!response.IsValidResponse)
        {
            throw new Exception($"Failed to index annotation: {response.ElasticsearchServerError}");
        }
    }

    public Annotation? GetAnnotation(Guid annotationId)
    {
        if (!_ready) throw new Exception("ElasticSearch is not ready");
        var response = _client.GetAsync<Annotation>(annotationId.ToString(), g => g.Index(IndexName))
            .GetAwaiter().GetResult();

        if (!response.IsValidResponse)
        {
            throw new Exception($"Failed to get annotation: {response.ElasticsearchServerError}");
        }

        return response.Source;
    }

    public Annotation[]? GetAnnotationsOfSong(string songId, int? offset, int? limit)
    {
        throw new NotImplementedException();
    }

    public Song[]? GetRecentlyAnnotatedSongs(int? offset, int? limit)
    {
        throw new NotImplementedException();
    }

    public Song[]? GetMostAnnotatedSongs(int? offset, int? limit)
    {
        throw new NotImplementedException();
    }

    public void DeleteAnnotation(Annotation annotation)
    {
        if (!_ready) return;
        throw new NotImplementedException();
    }
}