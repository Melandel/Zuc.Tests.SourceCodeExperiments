namespace Tests.Syntax.TestOnSystemWithStringOnlyApi.CustomFramework;

abstract class ArrangeActAndRenderReport<TInputDescription, TOutcomeRendering>
{
	public abstract TOutcomeRendering ArrangeThenActThenRenderReport(TInputDescription testCaseDescription);
}

abstract class ArrangeActAndRenderReportWithStringOnlyApi: ArrangeActAndRenderReport<string, string>
{
}
