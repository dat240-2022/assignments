using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Core.Domain.Cart.Pipelines;

public class Get
{
	public record Request(Guid CartId) : IRequest<ShoppingCart?>;


	public class Handler : IRequestHandler<Request, ShoppingCart?>
	{
		private readonly ShopContext _db;

		public Handler(ShopContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

		public async Task<ShoppingCart?> Handle(Request request, CancellationToken cancellationToken)
			=> await _db.ShoppingCart.Include(c => c.Items)
										.Where(c => c.Id == request.CartId)
										.SingleOrDefaultAsync(cancellationToken);

	}
}
