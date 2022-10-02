using System.Collections.Generic;

namespace UiS.Dat240.Lab3.SharedKernel;

public abstract class BaseEntity
{
	public List<BaseDomainEvent> Events = new();
}
