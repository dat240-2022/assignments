using System;
using UiS.Dat240.Lab3.Core.Domain.Products;

namespace UiS.Dat240.Lab3.Models;

public class FoodItemVM
{
	public FoodItemVM()
	{
	}

	public FoodItemVM(FoodItem? foodItem)
	{
		if (foodItem is null) throw new ArgumentNullException(nameof(foodItem));

		Id = foodItem.Id;
		Name = foodItem.Name;
		Description = foodItem.Description;
		Price = foodItem.Price;
		CookTime = foodItem.CookTime;
	}

	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
	public decimal Price { get; set; }
	public int CookTime { get; set; }
}
