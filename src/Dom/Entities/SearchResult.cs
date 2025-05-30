public class SearchResult<T>
{
    public IReadOnlyCollection<T> Items { get; set; } = [];
    public long Total { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
