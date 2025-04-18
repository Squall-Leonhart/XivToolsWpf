﻿// © XIV-Tools.
// Licensed under the MIT license.

namespace XivToolsWpf;

using System.Text.RegularExpressions;

public static class SearchUtility
{
	public static bool Matches(string? input, string[]? querry)
	{
		if (input == null)
			return false;

		if (querry == null)
			return true;

		input = input.ToLower();
		input = Regex.Replace(input, @"[^\w\d\s]", string.Empty);

		bool matchesSearch = true;
		foreach (string str in querry)
		{
			string strB = str.ToLower();

			// ignore 'the'
			if (strB == "the")
				continue;

			// ignore all symbols
			strB = Regex.Replace(strB, @"[^\w\d\s]", string.Empty);

			// Parse integers as numbers instead of strings
			if (int.TryParse(str, out int v))
			{
				matchesSearch &= input.Contains(v.ToString());
			}
			else
			{
				matchesSearch &= input.Contains(strB);
			}
		}

		if (!matchesSearch)
		{
			return false;
		}

		return true;
	}
}
