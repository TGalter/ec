using Dom.Entities;

namespace App.Interfaces;

public interface IElasticSearchService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(Guid id);
    Task<SearchResult<Product>> SearchProductsAsync(string searchTerm, int page = 1, int pageSize = 10);
}
