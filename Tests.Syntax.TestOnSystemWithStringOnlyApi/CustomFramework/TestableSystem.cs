using System.Text;

namespace Tests.Syntax.TestOnSystemWithStringOnlyApi.CustomFramework;

abstract class TestableSystem<TTestCaseDescription, TTestOutcomeRendering>
{
	public TTestOutcomeRendering TestAgainst(TTestCaseDescription testCaseDescription)
	{
		try { return RunTestCase(testCaseDescription); }
		catch (Exception exception) { return HandleException(exception, testCaseDescription); }
	}
	public abstract TTestOutcomeRendering RunTestCase(TTestCaseDescription testCaseDescription);
	public abstract TTestOutcomeRendering HandleException(Exception exception, TTestCaseDescription testCaseDescription);
}

class TestableSystemWithStringOnlyApi : TestableSystem<string, string>
{
	readonly ArrangeActAndRenderReport<string, string> _aarWithStringOnlyApi;
	public TestableSystemWithStringOnlyApi(ArrangeActAndRenderReport<string, string> arrangeActAndRenderReportWithStringOnlyApi)
	{
		_aarWithStringOnlyApi = arrangeActAndRenderReportWithStringOnlyApi;
	}

	public override string RunTestCase(string testCaseDescription)
	{
		return _aarWithStringOnlyApi.ArrangeThenActThenRenderReport(testCaseDescription);
	}

	public override string HandleException(Exception exception, string testCaseDescription)
	{
		var sb = new StringBuilder();
		var ex = exception;
		do {
			sb.Append(ex.GetType().Name);
			sb.Append(": ");
			sb.AppendLine(ex.Message);
			ex = ex.InnerException;
		} while(ex?.InnerException != null);
		return sb.ToString();
	}
}

