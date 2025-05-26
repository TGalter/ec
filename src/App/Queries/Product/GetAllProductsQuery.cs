using MediatR;
using Dom.Entities;
using System.Collections.Generic;

namespace App.Queries.Product;

public record GetAllProductsQuery() : IRequest<IEnumerable<Dom.Entities.Product>>;

