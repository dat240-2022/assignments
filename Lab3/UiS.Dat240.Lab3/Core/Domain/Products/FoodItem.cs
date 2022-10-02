using System;
using System.Collections.Generic;
using UiS.Dat240.Lab3.Core.Domain.Products.Events;
using UiS.Dat240.Lab3.SharedKernel;

namespace UiS.Dat240.Lab3.Core.Domain.Products;

public class FoodItem : BaseEntity
{

	public FoodItem(string name, string description)
	{
		_name = name;
		Description = description;
	}
	public int Id { get; protected set; }

	private string _name;
	public string Name
	{
		get => _name;
		set
		{
			if (_name is not null && _name != "" && _name != value)
			{
				Events.Add(new FoodItemNameChanged(Id, oldName: _name, newName: value));
				_name = value;
			}
		}
	}
	public string Description { get; set; }
	public decimal Price { get; set; }
	public int CookTime { get; set; }
}

public class FoodItemNameValidator : IValidator<FoodItem>
{
	public (bool, string) IsValid(FoodItem item)
	{
		_ = item ?? throw new ArgumentNullException(nameof(item), "Cannot validate a null object");
		if (string.IsNullOrWhiteSpace(item.Name)) return (false, $"{nameof(item.Description)} cannot be empty");
		return (true, "");
	}
}
public class FoodItemDescriptionValidator : IValidator<FoodItem>
{
	public (bool, string) IsValid(FoodItem item)
	{
		_ = item ?? throw new ArgumentNullException(nameof(item), "Cannot validate a null object");
		if (string.IsNullOrWhiteSpace(item.Description)) return (false, $"{nameof(item.Description)} cannot be empty");
		return (true, "");
	}
}
public class FoodItemPriceValidator : IValidator<FoodItem>
{
	public (bool, string) IsValid(FoodItem item)
	{
		_ = item ?? throw new ArgumentNullException(nameof(item), "Cannot validate a null object");
		if (item.Price <= 0) return (false, $"{nameof(item.Price)} must be greater than 0");
		return (true, "");
	}
}
