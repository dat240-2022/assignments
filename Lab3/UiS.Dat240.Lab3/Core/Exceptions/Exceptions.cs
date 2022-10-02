using System;

namespace UiS.Dat240.Lab3.Core.Exceptions;

// How to create user-defined exceptions
// https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
public class BaseException : Exception
{
	public BaseException()
	{
	}

	public BaseException(string? message) : base(message)
	{
	}

	public BaseException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}

public class EntityNotFoundException : BaseException
{
	public EntityNotFoundException()
	{
	}

	public EntityNotFoundException(string? message) : base(message)
	{
	}

	public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}

