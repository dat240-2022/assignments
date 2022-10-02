using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Ordering;
using UiS.Dat240.Lab3.Core.Domain.Ordering.Dto;

namespace UiS.Dat240.Lab3.Core.Domain.Ordering.Services;

public interface IOrderingService
{
    Task<int> PlaceOrder(Location location, string customerName, OrderLineDto[] orderLines);
}