using Tests.Syntax.TestOnSystemWithStringOnlyApi.CustomFramework;

namespace Tests.Syntax.TestOnSystemWithStringOnlyApi.TestSuite;

class CustomDividerAAR : ArrangeActAndRenderReportWithStringOnlyApi
{
	public override string ArrangeThenActThenRenderReport(string testCaseDescription)
	{
		// Arrange
		(int numerator, int denominator) = testCaseDescription.Split(':').Select(int.Parse).ToArray() switch
		{
			[int num, int den] => (num, den),
			_ => throw new InvalidOperationException()
		};
		var sut = new CustomDivider();

		// Act
		var output = sut.Divide(numerator, denominator);

		// Render
		return output.ToString();
	}
}
