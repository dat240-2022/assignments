using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Cart;
using UiS.Dat240.Lab3.Core.Domain.Cart.Pipelines;
using UiS.Dat240.Lab3.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace UiS.Dat240.Lab3.Pages;

public class CartModel : PageModel
{
	private readonly IMediator _mediator;

	public CartModel(IMediator mediator) => _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));

	public ShoppingCart? Cart { get; private set; }

	public async Task OnGetAsync()
	{
		var cartId = HttpContext.Session.GetGuid("CartId");
		if (cartId is null) return;

		Cart = await _mediator.Send(new Get.Request(cartId.Value));
	}
}
