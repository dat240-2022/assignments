using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Products.Pipelines;
using UiS.Dat240.Lab3.Core.Exceptions;
using UiS.Dat240.Lab3.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UiS.Dat240.Lab3.Pages.Products;

public class EditModel : PageModel
{
	private readonly IMediator _mediator;


	public EditModel(IMediator mediator)
	{
		_mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
	}

	public FoodItemVM? Item { get; private set; }
	public string[] Errors { get; private set; } = System.Array.Empty<string>();

	public async Task<IActionResult> OnGetAsync(int id)
	{
		try
		{
			Item = new FoodItemVM(await _mediator.Send(new GetById.Request(id)));
			return Page();
		}
		catch (EntityNotFoundException)
		{
			return NotFound();
		}
	}

	public async Task<IActionResult> OnPostAsync(FoodItemVM item)
	{
		var result = await _mediator.Send(new Edit.Request(item.Id, item.Name, item.Description, item.Price, item.CookTime));
		if (result.Success) return RedirectToPage(new { item.Id });

		Item = item;

		Errors = result.Errors;
		return Page();

	}
}
