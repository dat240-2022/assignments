using System;
using Microsoft.AspNetCore.Http;

namespace UiS.Dat240.Lab3.Helpers;

public static class SessionExtensions
{
	public static Guid? GetGuid(this ISession session, string key)
	{
		if (session == null) return null;
		var str = session.GetString(key);
		if (str == null) return null;
		if (Guid.TryParse(str, out var guid))
		{
			return guid;
		}
		return null;
	}
}
