using System;
using UiS.Dat240.Lab3.SharedKernel;

namespace UiS.Dat240.Lab3.Core.Domain.Cart;

public class CartItem : BaseEntity
{
	public CartItem(int sku, string name, decimal price)
	{
		Sku = sku;
		Name = name;
		Price = price;
		Count = 1;
	}
	public Guid Id { get; protected set; }

	public int Sku { get; private set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public decimal Sum => Price * Count;

	public int Count { get; private set; }

	public void AddOne() => Count++;
}
