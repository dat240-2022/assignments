using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Products;
using UiS.Dat240.Lab3.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UiS.Dat240.Lab3.Pages;

public class IndexModel : PageModel
{
	private readonly IMediator _mediator;
	public IndexModel(IMediator mediator) => _mediator = mediator;

	public List<FoodItem> FoodItems { get; set; } = new();

	public async Task OnGetAsync()
		=> FoodItems = await _mediator.Send(new Core.Domain.Products.Pipelines.Get.Request());

	public async Task<IActionResult> OnPostAddToCartAsync(int id, string name, decimal price)
	{
		var cartId = HttpContext.Session.GetGuid("CartId");
		if (cartId == null)
		{
			cartId = Guid.NewGuid();
			HttpContext.Session.SetString("CartId", cartId.ToString());
		}

		await _mediator.Send(new Core.Domain.Cart.Pipelines.AddItem.Request(id, name, price, cartId.Value));

		return RedirectToPage();
	}
}
