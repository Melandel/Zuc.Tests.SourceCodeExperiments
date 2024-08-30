using System.Text;
namespace Tests.Syntax.TestOnGherkinWithStringOnlyApi.CustomFramework;

	public class DescribeExecuteRender<TUsageContext>
		where TUsageContext: IDescribeTestInputAndRenderTestOutcomeWithStrings
	{
		enum Clause { Given, When, Then };

		readonly Func<TUsageContext> _arrangeFunction;
		Func<TUsageContext, string>? _actFunction;
		Clause _latestSentencePartDefined;

		DescribeExecuteRender(Func<TUsageContext> arrangeFunction)
		{
			_arrangeFunction = arrangeFunction;
			_latestSentencePartDefined = Clause.Given;
		}

		public static DescribeExecuteRender<TUsageContext> Given(string testCaseInputDescription)
		{
			var testContituentsBuilder = TUsageContext.BuildTestInputAndSystemUnderTestFromStringDescription(testCaseInputDescription.ToUnindentedFormat());
			var arrangeFunction = () => (TUsageContext) (testContituentsBuilder.Invoke());
			return new(arrangeFunction);
		}

		public DescribeExecuteRender<TUsageContext> When(Func<TUsageContext, string> actFunction)
		{
			if (_latestSentencePartDefined is not Clause.Given) throw new Exception();

			_actFunction = actFunction;

			_latestSentencePartDefined = Clause.When;
			return this;
		}

		public DescribeExecuteRender<TUsageContext> Then(params string[] testCaseExpectationsDescription)
		{
			var expectedOutcomeDescription = String.Join(Environment.NewLine, testCaseExpectationsDescription);

			if (_latestSentencePartDefined is not Clause.When) throw new Exception();
			var unindentedTestCaseExpectationsDescription = expectedOutcomeDescription.ToUnindentedFormat();

			var testEnv = _arrangeFunction.Invoke();

			try
			{
				var stringifiedMethodOutput = _actFunction!.Invoke(testEnv);

				if (!string.Equals(unindentedTestCaseExpectationsDescription, stringifiedMethodOutput, StringComparison.InvariantCulture))
				{
					var feedback = new StringBuilder();
					feedback.AppendLine($"Expected:        {unindentedTestCaseExpectationsDescription}");
					feedback.AppendLine($"But got instead: {stringifiedMethodOutput}");

					_latestSentencePartDefined = Clause.Then;
					throw new Exception(feedback.ToString());
				}
			}
			finally
			{
				_latestSentencePartDefined = Clause.Then;
			}

			return this;
		}
	}
