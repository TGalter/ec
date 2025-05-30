using MediatR;
using Dom.Entities;
using System.Collections.Generic;
using App.DTOs;

namespace App.Queries.Product;

public record SearchProductsQuery : IRequest<SearchResult<ProductDto>>
{
    public string SearchTerm { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public SearchProductsQuery(string searchTerm, int page = 1, int pageSize = 10)
    {
        SearchTerm = searchTerm;
        Page = page;
        PageSize = pageSize;
    }
}

