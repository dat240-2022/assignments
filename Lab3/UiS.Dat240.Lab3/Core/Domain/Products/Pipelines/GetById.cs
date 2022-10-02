using System;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Exceptions;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Core.Domain.Products.Pipelines;

public class GetById
{
	public record Request(int Id) : IRequest<FoodItem?>;

	public class Handler : IRequestHandler<Request, FoodItem?>
	{
		private readonly ShopContext _db;

		public Handler(ShopContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

		public async Task<FoodItem?> Handle(Request request, CancellationToken cancellationToken)
		{
			var item = await _db.FoodItems.SingleOrDefaultAsync(fi => fi.Id == request.Id, cancellationToken);
			if (item is null) throw new EntityNotFoundException($"FoodItem with Id {request.Id} was not found in the database");
			return item;
		}
	}
}
