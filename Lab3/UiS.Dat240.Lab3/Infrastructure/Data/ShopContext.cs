using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Cart;
using UiS.Dat240.Lab3.Core.Domain.Products;
using UiS.Dat240.Lab3.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab3.Infrastructure.Data;

public class ShopContext : DbContext
{
	private readonly IMediator _mediator;

	public ShopContext(DbContextOptions configuration, IMediator mediator) : base(configuration)
	{
		_mediator = mediator;
	}

	public DbSet<FoodItem> FoodItems { get; set; } = null!;
	public DbSet<ShoppingCart> ShoppingCart { get; set; } = null!;

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
		base.OnModelCreating(modelBuilder);
}

public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

		// ignore events if no dispatcher provided
		if (_mediator == null) return result;

		// dispatch events only if save was successful
		var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
			.Select(e => e.Entity)
			.Where(e => e.Events.Any())
			.ToArray();

		foreach (var entity in entitiesWithEvents)
		{
			var events = entity.Events.ToArray();
			entity.Events.Clear();
			foreach (var domainEvent in events)
			{
				await _mediator.Publish(domainEvent, cancellationToken);
			}
		}
		return result;
	}

	public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}

internal class FakeData
{
	public static FoodItem[] FoodItems { get; private set; } = new FoodItem[0];

	internal static void Init()
	{
		var lorem = new Bogus.DataSets.Lorem();
		var random = new Bogus.Randomizer();
		FoodItems = Enumerable.Range(1, 30).Select(i =>
			{
				var item = new FoodItem(lorem.Sentence(3, 2), lorem.Sentence(10, 10))
				{
					Price = random.Decimal(50, 250) + .99m,
					CookTime = random.Number(5, 20)
				};

				// End the statement with a bang (!) to tell the compiler that the return object will never be null.
				// We know this exists and if it actually is null then it should blow up when seeding. Something is obviously wrong then and it should fail hard. 
				PropertyInfo propertyInfo = typeof(FoodItem).GetProperty(nameof(item.Id))!;
				propertyInfo.SetValue(item, i);
				return item;
			}).ToArray();

	}
}
