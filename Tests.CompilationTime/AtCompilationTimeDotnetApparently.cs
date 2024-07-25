using Tests.TestData;

namespace Tests.Records;

public class AtCompilationTimeDotnetApparently
{
	public const string Str = "toto";
	[Test]
	public void Is_CaseSensitive_With_NameOf()
	{
		// Arrange
		var str = nameof(Str);

		// Assert
		Assert.That(str, Is.EqualTo("Str"));
	}
}
