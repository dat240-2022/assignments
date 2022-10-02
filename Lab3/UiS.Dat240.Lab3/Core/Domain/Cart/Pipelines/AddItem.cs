using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Core.Domain.Cart.Pipelines;

public class AddItem
{
	public record Request(
		int ItemId,
		string ItemName,
		decimal ItemPrice,
		Guid CartId) : IRequest<Unit>;

	public record Response(bool Success, string[] Errors);

	public class Handler : IRequestHandler<Request, Unit>
	{
		private readonly ShopContext _db;

		public Handler(ShopContext db) => _db = db ?? throw new ArgumentNullException(nameof(db));

		public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
		{
			var cart = _db.ShoppingCart.Include(c => c.Items).SingleOrDefault(c => c.Id == request.CartId);
			if (cart == null)
			{
				cart = new ShoppingCart(request.CartId);
				_db.ShoppingCart.Add(cart);
			}
			cart.AddItem(request.ItemId, request.ItemName, request.ItemPrice);


			await _db.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}

	}
}
