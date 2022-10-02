using System;
using System.Linq;
using System.Threading;
using UiS.Dat240.Lab3.Core.Domain.Cart.Pipelines;
using UiS.Dat240.Lab3.Infrastructure.Data;
using UiS.Dat240.Lab3.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace UiS.Dat240.Lab3.Tests.Core.Domain.Cart.Pipelines;

public class AddItemTests : DbTest
{
	public AddItemTests(ITestOutputHelper output) : base(output)
	{
	}

	[Fact]
	public void AddNewItem_AddsOneItem()
	{
		var cartId = Guid.NewGuid();
		var request = new AddItem.Request(1, "Test", 1m, cartId);

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.Database.Migrate();

			var handler = new AddItem.Handler(context);

			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();
		}
		using (var context = new ShopContext(ContextOptions, null))
		{
			context.ShoppingCart.Count().ShouldBe(1);

			context.ShoppingCart.Include(c => c.Items).Single().Items.Count().ShouldBe(1);
		}
	}

	[Fact]
	public void AddNewItemTwice_IncrementsItemCount()
	{
		var cartId = Guid.NewGuid();
		var request = new AddItem.Request(1, "Test", 1m, cartId);

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.Database.Migrate();

			var handler = new AddItem.Handler(context);

			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();
		}

		// Use a new context to prevent cached entities from short circuiting the database. 
		using (var context = new ShopContext(ContextOptions, null))
		{
			var handler = new AddItem.Handler(context);

			// Add it twice
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();
		}

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.ShoppingCart.Count().ShouldBe(1);

			context.ShoppingCart.Include(c => c.Items).Single().Items.Count().ShouldBe(1);
			context.ShoppingCart.Include(c => c.Items).Single().Items.Single().Count.ShouldBe(2);
		}
	}
}
