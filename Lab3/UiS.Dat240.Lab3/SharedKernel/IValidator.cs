using System.Collections.Generic;

namespace UiS.Dat240.Lab3.SharedKernel;

public interface IValidator<T>
{
	(bool IsValid, string Error) IsValid(T item);
}
