namespace Tests.ClassBasedEnums;

public class EnumsApparently
{
	[Test]
	public void Finds_By_Name()
	{
		Assert.That(MyEnum.ThatMatches("Foo"), Is.EqualTo(MyEnum.Foo));
		Assert.That(MyEnum.ThatMatches("Bar"), Is.EqualTo(MyEnum.Bar));
		Assert.That(MyEnum.ThatMatches("Baz"), Is.EqualTo(MyEnum.Baz));
	}

	[Test]
	public void Returns_Correctly_AllPossibleValues()
	{
		Assert.That(MyEnum.AllPossibleValues, Is.EquivalentTo(new[] { MyEnum.Foo, MyEnum.Bar, MyEnum.Baz }));
	}

	public class MyEnum : ClassBasedEnum<MyEnum>
	{
		MyEnum(string name) : base(name) { }
		public static readonly MyEnum Foo = new(nameof(Foo));
		public static readonly MyEnum Bar = new(nameof(Bar));
		public static readonly MyEnum Baz = new(nameof(Baz));
	}
}
