using experitone_api.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
namespace experitone_api;

public class ElasticSearchHandler : ISearchEngineHandler
{
    private readonly ElasticsearchClient _client;
    public bool Ready = false;
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
                            .IntegerNumber(x => x.Details.StartTimestamp)
                            .IntegerNumber(x => x.Details.EndTimestamp)
                            .Text(x => x.Details.Title)
                            .Text(x => x.Details.Description)
                            .Text(x => x.Details.AuthorId)
                        )
                    )
                )
            )
        );

        if (!createResponse.Acknowledged || !createResponse.IsValidResponse)
        {
            throw new Exception($"Error creating index: {createResponse.ElasticsearchServerError}");
        }

        Ready = true;
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

    public void PutAnnotation()
    {
        throw new NotImplementedException();
    }

    public Annotation[] GetAnnotations(string? query, int? offset, int? limit)
    {
        throw new NotImplementedException();
    }

    public void DeleteAnnotation(Annotation annotation)
    {
        throw new NotImplementedException();
    }
}