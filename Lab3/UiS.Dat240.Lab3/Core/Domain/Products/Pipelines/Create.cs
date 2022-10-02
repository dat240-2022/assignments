using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Infrastructure.Data;
using UiS.Dat240.Lab3.SharedKernel;
using MediatR;

namespace UiS.Dat240.Lab3.Core.Domain.Products.Pipelines;

public class Create
{
	public record Request(string Name, string Description, decimal Price, int Cooktime) : IRequest<Response>;

	public record Response(bool Success, FoodItem createdItem, string[] Errors);

	public class Handler : IRequestHandler<Request, Response>
	{
		private readonly ShopContext _db;
		private readonly IEnumerable<IValidator<FoodItem>> _validators;

		public Handler(ShopContext db, IEnumerable<IValidator<FoodItem>> validators)
		{
			_db = db ?? throw new ArgumentNullException(nameof(db));
			_validators = validators ?? throw new ArgumentNullException(nameof(validators));
		}

		public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
		{
			var foodItem = new FoodItem(request.Name, request.Description)
			{
				Price = request.Price,
				CookTime = request.Cooktime
			};

			var errors = _validators.Select(v => v.IsValid(foodItem))
						.Where(result => !result.IsValid)
						.Select(result => result.Error)
						.ToArray();
			if (errors.Length > 0)
			{
				return new Response(Success: false, foodItem, errors);
			}

			_db.FoodItems.Add(foodItem);
			await _db.SaveChangesAsync(cancellationToken);

			return new Response(true, foodItem, Array.Empty<string>());
		}
	}
}
