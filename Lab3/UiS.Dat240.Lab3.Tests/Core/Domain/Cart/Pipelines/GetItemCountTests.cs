using System;
using System.Threading;
using UiS.Dat240.Lab3.Core.Domain.Cart.Pipelines;
using UiS.Dat240.Lab3.Infrastructure.Data;
using UiS.Dat240.Lab3.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace UiS.Dat240.Lab3.Tests.Core.Domain.Cart.Pipelines;

public class GetItemCountTests : DbTest
{
	public GetItemCountTests(ITestOutputHelper output) : base(output)
	{
	}

	[Fact]
	public void NoCart_ShouldReturn0()
	{
		var cartId = Guid.NewGuid();
		var request = new GetItemCount.Request(cartId);

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.Database.Migrate();

			var handler = new GetItemCount.Handler(context);

			var itemCount = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			itemCount.ShouldBe(0);
		}
	}

	[Fact]
	public void CartWithOneItem_ShouldReturn1()
	{
		var cartId = Guid.NewGuid();

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.Database.Migrate();
			var request = new AddItem.Request(1, "Test", 1m, cartId);
			var handler = new AddItem.Handler(context);
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();
		}

		// Use a new context to prevent cached entities from short circuiting the database. 
		using (var context = new ShopContext(ContextOptions, null))
		{
			var request = new GetItemCount.Request(cartId);
			var handler = new GetItemCount.Handler(context);
			var itemCount = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			itemCount.ShouldBe(1);
		}
	}


	[Fact]
	public void TwoCartWithOneItemEach_ShouldReturn1()
	{
		var cartId = Guid.NewGuid();

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.Database.Migrate();
			var handler = new AddItem.Handler(context);
			var request = new AddItem.Request(1, "Test", 1m, cartId);
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			request = new AddItem.Request(1, "Test", 1m, Guid.NewGuid());
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();
		}

		// Use a new context to prevent cached entities from short circuiting the database. 
		using (var context = new ShopContext(ContextOptions, null))
		{
			var handler = new GetItemCount.Handler(context);

			var request = new GetItemCount.Request(cartId);
			var itemCount = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			itemCount.ShouldBe(1);
		}
	}

	[Fact]
	public void CartWithTwoItems_ShouldReturn2()
	{
		var cartId = Guid.NewGuid();

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.Database.Migrate();
			var handler = new AddItem.Handler(context);

			var request = new AddItem.Request(1, "Test", 1m, cartId);
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			request = new AddItem.Request(2, "Test 2", 1m, cartId);
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();
		}

		// Use a new context to prevent cached entities from short circuiting the database. 
		using (var context = new ShopContext(ContextOptions, null))
		{
			var request = new GetItemCount.Request(cartId);
			var handler = new GetItemCount.Handler(context);
			var itemCount = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			itemCount.ShouldBe(2);
		}
	}

	[Fact]
	public void CartWithTwoItemsWithTwoOfOne_ShouldReturn3()
	{
		var cartId = Guid.NewGuid();

		using (var context = new ShopContext(ContextOptions, null))
		{
			context.Database.Migrate();
			var handler = new AddItem.Handler(context);

			var request = new AddItem.Request(1, "Test", 1m, cartId);
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			request = new AddItem.Request(2, "Test 2", 1m, cartId);
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			request = new AddItem.Request(2, "Test 2", 1m, cartId);
			_ = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();
		}

		// Use a new context to prevent cached entities from short circuiting the database. 
		using (var context = new ShopContext(ContextOptions, null))
		{
			var request = new GetItemCount.Request(cartId);
			var handler = new GetItemCount.Handler(context);
			var itemCount = handler.Handle(request, CancellationToken.None).GetAwaiter().GetResult();

			itemCount.ShouldBe(3);
		}
	}
}
