namespace Tests.Syntax.TestOnGherkinWithStringOnlyApi.CustomFramework;

class TestsOnGherkinWithStringOnlyApi<TUsageContext> where TUsageContext: IDescribeTestInputAndRenderTestOutcomeWithStrings
{
	protected DescribeExecuteRender<TUsageContext> Given(string testCaseDescription)
	{
		return DescribeExecuteRender<TUsageContext>.Given(testCaseDescription);
	}
}

