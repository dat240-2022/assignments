using System;
using System.Linq;
using UiS.Dat240.Lab3.Core.Domain.Cart;
using Shouldly;
using Xunit;

namespace UiS.Dat240.Lab3.Tests.Core.Domain.Cart;

public class ShoppingCartTests
{
	[Fact]
	public void AddNewItem_AddsOneItem()
	{
		var cart = new ShoppingCart(Guid.NewGuid());

		cart.AddItem(1, "Test", 1.00m);

		cart.Items.Count().ShouldBe(1);

		cart.Items.ShouldAllBe(i => i.Count == 1);
	}

	[Fact]
	public void AddNewItemTwice_IncrementsItemCount()
	{
		var cart = new ShoppingCart(Guid.NewGuid());

		cart.AddItem(1, "Test", 1.00m);
		cart.AddItem(1, "Test", 1.00m);

		cart.Items.Count().ShouldBe(1);

		cart.Items.ShouldAllBe(i => i.Count == 2);
	}
}
