using System.Reflection;

namespace Tests.ClassBasedEnums;

public abstract class ClassBasedEnum<TDerived>
	where TDerived : ClassBasedEnum<TDerived>
{
	readonly string _name;
	protected ClassBasedEnum(string name)
	{
		_name = name;
	}

	public static IReadOnlyCollection<TDerived> AllPossibleValues => _allPossibleValues.Value;
	static Lazy<IReadOnlyCollection<TDerived>> _allPossibleValues = new(() =>
		typeof(TDerived)
		.GetMembers(BindingFlags.Static | BindingFlags.Public)
		.OfType<FieldInfo>()
		.Where(f => typeof(TDerived).IsAssignableFrom(f.FieldType))
		.Select(f => (TDerived)f.GetValue(null)!)
		.ToArray());

	public static TDerived ThatMatches(string name)
	=> _allPossibleValues.Value.FirstOrDefault(enumValue => string.Equals(name, enumValue, StringComparison.InvariantCultureIgnoreCase));

	public static TDerived ThatMatches(string environmentName, TDerived defaultValue)
	=> ThatMatches(environmentName) ?? defaultValue;

	public static implicit operator string(ClassBasedEnum<TDerived> enumValue) => enumValue._name;
}
