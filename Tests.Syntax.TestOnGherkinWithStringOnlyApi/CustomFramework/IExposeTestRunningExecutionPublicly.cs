namespace Tests.Syntax.TestOnGherkinWithStringOnlyApi.CustomFramework;

public interface IExposeTestRunningExecutionPublicly
{
	static abstract Func<IExecuteTheTestAndRenderItsOutcomeAsString, string> ExecuteAndRender { get; }
}
