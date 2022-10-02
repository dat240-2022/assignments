using System;
using System.Collections.Generic;
using System.Linq;
using UiS.Dat240.Lab3.SharedKernel;

namespace UiS.Dat240.Lab3.Core.Domain.Cart;

public class ShoppingCart : BaseEntity
{
	public ShoppingCart(Guid id) => Id = id;
	public Guid Id { get; protected set; }

	private readonly List<CartItem> _items = new();
	public IEnumerable<CartItem> Items => _items.AsReadOnly();

	public void AddItem(int itemId, string itemName, decimal itemPrice)
	{
		var item = _items.SingleOrDefault(item => item.Sku == itemId);
		if (item == null)
		{
			item = new(itemId, itemName, itemPrice);
			_items.Add(item);
			return;
		}
		item.AddOne();
	}

}
