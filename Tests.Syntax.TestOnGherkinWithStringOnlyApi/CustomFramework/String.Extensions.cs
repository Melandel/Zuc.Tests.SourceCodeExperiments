using System.Text.RegularExpressions;

namespace Tests.Syntax.TestOnGherkinWithStringOnlyApi.CustomFramework;

static class StringExtensions
{
	public static string ToUnindentedFormat(this string str)
	=> String.Join(
		Environment.NewLine,
		str
			.Split(Environment.NewLine)
			.Where(str => !str.Trim().StartsWith('#'))
			.Select(str => Regex.Replace(str, @"^\s+\|", "")));
}
