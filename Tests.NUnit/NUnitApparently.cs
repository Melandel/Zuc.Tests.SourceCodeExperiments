using Tests.TestData;

namespace Tests.Records;

public class NUnitApparently
{
	[Test]
	public void Accepts_The_Constraint__Has_One_Items__For_Single_Item_Collections()
	{
		// Arrange
		var array = new[] { 42 };

		// Assert
		Assert.That(array, Has.One.Items);
	}
}
