using Tests.Syntax.TestOnGherkinWithStringOnlyApi.CustomFramework;

namespace Tests.Syntax.TestOnGherkinWithStringOnlyApi.TestSuite;

class CustomDividerShould : TestsOnGherkinWithStringOnlyApi<CustomDividerGherkin>
{
	[Test]
	public void Return_Integer_Quotient()
		=> Given("-4:2")
			.When(CustomDividerGherkin.ExecuteAndRender)
			.Then("-2");

	[Test]
	public void RoundDown_NonInteger_Positive_Quotients()
	=> Given("199:100")
		.When(CustomDividerGherkin.ExecuteAndRender)
		.Then("1");

	[Test]
	public void RoundUp_NonInteger_Negative_Quotients()
	=> Given("-199:100")
		.When(CustomDividerGherkin.ExecuteAndRender)
		.Then("-1");

	[Test]
	public void Throw_DivideByZeroException()
	=> Given("1:0")
		.When(CustomDividerGherkin.ExecuteAndRender)
		.Then("DivideByZeroException");
}
