using App.DTOs;
using App.Interfaces;
using AutoMapper;
using Dom.Entities;
using Dom.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Queries.Product
{
    public class SearchProductsHandler : IRequestHandler<SearchProductsQuery, SearchResult<ProductDto>>
    {
        private readonly IElasticSearchService _elasticSearchService;
        private readonly IMapper _mapper;

        public SearchProductsHandler(IElasticSearchService elasticSearchService, IMapper mapper)
        {
            _elasticSearchService = elasticSearchService;
            _mapper = mapper;
        }

        public async Task<SearchResult<ProductDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var response = await _elasticSearchService.SearchProductsAsync(
            request.SearchTerm,
            request.Page,
            request.PageSize);

            return _mapper.Map<SearchResult<ProductDto>>(response);
        }
    }
}

