namespace Tests.Syntax.TestOnSystemWithStringOnlyApi;

public class CustomDivider
{
	public int Divide(int a, int b)
	=> b switch
	{
		0 => throw new DivideByZeroException(),
		_ => a/b
	};
}

