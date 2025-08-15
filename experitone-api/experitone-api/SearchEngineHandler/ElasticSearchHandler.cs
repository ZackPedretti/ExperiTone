using System.Text.Json;
using experitone_api.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
namespace experitone_api;

public class ElasticSearchHandler : ISearchEngineHandler
{
    private readonly ElasticsearchClient _client;
    private bool _ready;
    private const string IndexName = "annotations";

    private async Task InitializeIndex()
    {
        var existsResponse = await _client.Indices.ExistsAsync(IndexName);
        if (existsResponse.Exists)
        {
            _ready = true;
            return;
        }

        var createResponse = await _client.Indices.CreateAsync<Annotation>(index => index
            .Index(IndexName)
            .Mappings(mappings => mappings
                .Properties(properties => properties
                    .Keyword(x => x.VideoId)
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

    public Annotation[] GetAnnotationsOfSong(string videoId, int? offset, int? limit)
    {
        var response = _client.SearchAsync<Annotation>(s => s
                .Indices(IndexName)
                .Query(q => q.Term(t => t
                    .Field(f => f.VideoId)
                    .Value(videoId)
                ))
                .From(offset ?? 0)
                .Size(limit ?? 100)
        ).GetAwaiter().GetResult();

        if (!response.IsValidResponse)
        {
            throw new Exception($"Failed to search annotations: {response.ElasticsearchServerError}");
        }

        return response.Documents.ToArray();
    }

    public Song[] GetRecentlyAnnotatedSongs(int? offset, int? limit)
    {
        throw new NotImplementedException();
    }

    public Song[] GetMostAnnotatedSongs(int? offset, int? limit)
    {
        throw new NotImplementedException();
    }

    public Song?[]? SearchSong(string query, int? offset, int? limit)
    {
        if (!_ready) throw new Exception("ElasticSearch is not ready");

        var response = _client.SearchAsync<Annotation>(s => s
            .Indices(IndexName)
            .Size(0)
            .Query(q => q
                .MultiMatch(m => m
                    .Query(query)
                    .Fields(
                        f => f.VideoId,
                        f => f.Title,
                        f => f.Author,
                        f => f.Description,
                        f => f.Details.Title,
                        f => f.Details.Description
                    )
                )
            )
            .Aggregations(aggregations => aggregations
                .Add("song", aggregation => aggregation
                    .Terms(terms => terms
                        .Field(f => f.VideoId)
                    )
                    .Aggregations(agg => agg
                        .Add("top_annotation", top => top
                            .TopHits(th => th
                                .Size(1)
                            )
                        )
                    )
                )
            )
            .Size(limit ?? 100)
        ).GetAwaiter().GetResult();

        if (!response.IsValidResponse)
        {
            throw new Exception($"Failed to search songs: {response.ElasticsearchServerError}");
        }

        Song?[]? songs = response.Aggregations?.GetStringTerms("song")
            ?.Buckets
            .Select(b =>
            {
                var topHitsAgg = b.Aggregations?.GetTopHits("top_annotation");
                var topHit = topHitsAgg?.Hits.Hits.FirstOrDefault();
                if (topHit?.Source is JsonElement json)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var annotation = JsonSerializer.Deserialize<Annotation>(json.GetRawText(), options);
                    if (annotation != null)
                    {
                        return new Song(
                            annotation.VideoId,
                            annotation.Title,
                            annotation.Author,
                            annotation.Description,
                            annotation.Duration
                        );
                    }
                }
                return null;
            })
            .Where(s => s != null)
            .ToArray();

        return songs;
    }

    public void DeleteAnnotation(Annotation annotation)
    {
        if (!_ready) return;
        throw new NotImplementedException();
    }
}