using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Exceptions;
using UiS.Dat240.Lab3.Infrastructure.Data;
using UiS.Dat240.Lab3.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Core.Domain.Products.Pipelines;

public class Edit
{
	public record Request(int Id, string Name, string Description, decimal Price, int Cooktime) : IRequest<Response>;

	public record Response(bool Success, string[] Errors);

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
			var existingItem = await _db.FoodItems.FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);
			if (existingItem is null) throw new EntityNotFoundException($"FoodItem with Id {request.Id} was not found in the database");

			existingItem.Name = request.Name;
			existingItem.Description = request.Description;
			existingItem.Price = request.Price;
			existingItem.CookTime = request.Cooktime;


			var errors = _validators.Select(v => v.IsValid(existingItem))
						.Where(result => !result.IsValid)
						.Select(result => result.Error)
						.ToArray();
			if (errors.Length > 0)
			{
				return new Response(Success: false, errors);
			}

			await _db.SaveChangesAsync(cancellationToken);
			return new Response(true, Array.Empty<string>());
		}
	}
}
