namespace Tests.Syntax.TestOnGherkinWithStringOnlyApi.CustomFramework;

public interface IBuildTestInputAndSystemUnderTestFromStringDescription
{
	static abstract Func<object> BuildTestInputAndSystemUnderTestFromStringDescription(params string[] testCaseDescription);
}

