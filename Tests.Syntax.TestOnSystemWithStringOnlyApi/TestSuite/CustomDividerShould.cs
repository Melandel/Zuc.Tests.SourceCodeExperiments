using Tests.Syntax.TestOnSystemWithStringOnlyApi.CustomFramework;

namespace Tests.Syntax.TestOnSystemWithStringOnlyApi.TestSuite;

class CustomDividerShould : TestsOnSystemWithStringOnlyApi<CustomDividerAAR>
{
	[Test]
	public void Return_Integer_Quotient()
	=> Assert.That(SUT.TestAgainst("-4:2"), Is.EqualTo("-2"));

	[Test]
	public void RoundDown_NonInteger_Positive_Quotients()
	=> Assert.That(SUT.TestAgainst("199:100"), Is.EqualTo("1"));

	[Test]
	public void RoundUp_NonInteger_Negative_Quotients()
	=> Assert.That(SUT.TestAgainst("-199:100"), Is.EqualTo("-1"));

	[Test]
	public void Throw_DivideByZeroException()
	=> Assert.That(SUT.TestAgainst("1:0"), Does.StartWith("DivideByZeroException"));
}
