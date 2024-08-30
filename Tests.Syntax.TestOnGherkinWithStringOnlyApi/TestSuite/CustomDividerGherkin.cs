using Tests.Syntax.TestOnGherkinWithStringOnlyApi.CustomFramework;

namespace Tests.Syntax.TestOnGherkinWithStringOnlyApi.TestSuite;

record CustomDividerGherkin(
	CustomDivider SystemUnderTest,
	int a,
	int b)
: IDescribeTestInputAndRenderTestOutcomeWithStrings
{
	public static Func<IExecuteTheTestAndRenderItsOutcomeAsString, string> ExecuteAndRender =>
		_ => _.ExecuteTheTestAndRenderItsOutcomeAsString();

	public string ExecuteTheTestAndRenderItsOutcomeAsString()
	{
		try
		{
			// Act
			var output = SystemUnderTest.Divide(a, b);

			// Render
			return output.ToString();
		}
		catch (Exception e)
		{
			return e.GetType().Name;
		}
	}

	public static Func<object> BuildTestInputAndSystemUnderTestFromStringDescription(params string[] testCaseDescription) =>
		() =>
		{
			var description = String.Join(Environment.NewLine, testCaseDescription);
			return description.Split(':').Select(int.Parse).ToArray() switch
			{
				[int a, int b] => new CustomDividerGherkin(new CustomDivider(), a, b),
				_ => throw new InvalidOperationException()
			};
		};
}
