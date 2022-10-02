using System;
using MediatR;

namespace UiS.Dat240.Lab3.SharedKernel;

public abstract record BaseDomainEvent : INotification
{
	public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
}
