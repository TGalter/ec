using Dom.Entities;
using Dom.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Queries.Product
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Dom.Entities.Product>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Dom.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

