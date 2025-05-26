using MediatR;
using App.DTOs;
using Dom.Interfaces;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Queries.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<ProductDto>(product);
        }
    }
}

