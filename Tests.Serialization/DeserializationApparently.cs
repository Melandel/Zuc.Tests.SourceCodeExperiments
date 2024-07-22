namespace Tests.Serialization;

public class DeserializationApparently
{
	[Test]
	public void Ignores_CaseSensitivity_ByDefault_When_Using_Newtonsoft_But_Not_When_Using_SystemTextJsonSerialization()
	{
		// Arrange
		var jsonWithoutUpperCasePropertyNamesKeyAndValue = @"{ ""key"": ""foo"", ""value"": ""bar"" }";

		// Act
		var kvpFromSystemTextJson = System.Text.Json.JsonSerializer.Deserialize<KeyValuePair<string, string>>(jsonWithoutUpperCasePropertyNamesKeyAndValue);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(kvpFromSystemTextJson.Key, Is.Null);
			Assert.That(kvpFromSystemTextJson.Value, Is.Null);

			var kvpFromNewtonsoft = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyValuePair<string, string>>(jsonWithoutUpperCasePropertyNamesKeyAndValue);
			Assert.That(kvpFromNewtonsoft.Key, Is.EqualTo("foo"));
			Assert.That(kvpFromNewtonsoft.Value, Is.EqualTo("bar"));

			var systemTextJsonOptions = new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
			var kvpFromSystemTextJsonWithOptions = System.Text.Json.JsonSerializer.Deserialize<KeyValuePair<string, string>>(jsonWithoutUpperCasePropertyNamesKeyAndValue, systemTextJsonOptions);
			Assert.That(kvpFromSystemTextJsonWithOptions.Key, Is.EqualTo("foo"));
			Assert.That(kvpFromSystemTextJsonWithOptions.Value, Is.EqualTo("bar"));
		});
	}
}

