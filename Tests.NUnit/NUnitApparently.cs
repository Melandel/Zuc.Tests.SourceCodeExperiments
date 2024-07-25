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

	[Test]
	public void Accepts_The_Constraint__Has_One_Items__For_Single_Item_Collections_Even_When_Item_Is_Null()
	{
		// Arrange
		var array = new int?[] { null };

		// Assert
		Assert.That(array, Has.One.Items);
	}
}
