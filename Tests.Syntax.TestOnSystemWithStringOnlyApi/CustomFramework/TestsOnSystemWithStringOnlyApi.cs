namespace Tests.Syntax.TestOnSystemWithStringOnlyApi.CustomFramework;

class TestsOnSystemWithStringOnlyApi<TArrangeActRenderReportWithStringOnlyApi> where TArrangeActRenderReportWithStringOnlyApi: ArrangeActAndRenderReportWithStringOnlyApi
{
#pragma warning disable 8618
	protected TestableSystemWithStringOnlyApi SUT;
#pragma warning restore

	[SetUp]
	public void SetUpSystemUnderTest()
	{
		var arrangeActRenderWithStringOnlyApi = Activator.CreateInstance<TArrangeActRenderReportWithStringOnlyApi>();
		var systemUnderTest = new TestableSystemWithStringOnlyApi(arrangeActRenderWithStringOnlyApi);
		SUT = systemUnderTest;
	}
}
