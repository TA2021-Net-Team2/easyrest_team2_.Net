using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Team2.Net.DataEntities;

namespace Team2.Net
{
    [TestFixture]
    public class APITests
    {
        [Test]
        public void StatusCodeTest()
        {
            // Arrange
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest("api/restaurant", Method.GET);

            // Action 
            IRestResponse response = client.Execute(request);

            // Assert
            // HttpStatusCode: 200 - good(OK), 404 - not found
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ContentTypeTest()
        {
            // arrange
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest("api/restaurant", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            //Check type json
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

        [TestCase("2", HttpStatusCode.OK, TestName = "Found Johnson PLC")]
        [TestCase("123", HttpStatusCode.NotFound, TestName = "Not found Non-name")]
        public void StatusCodeTest(string restId, HttpStatusCode expectedHttpStatusCode)
        {
            // Arrange
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest($"api/restaurant/{restId}", Method.GET);

            // Act
            IRestResponse response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [Test]
        public void RestaurantNameCorrectTest()
        {
            // Arrange
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest("api/restaurant/{restId}", Method.GET);
            request.AddUrlSegment("restId", 2);

            // Action
            IRestResponse response = client.Execute(request);

            RestaurantInfo locationResponse =
                new JsonDeserializer().
                Deserialize<RestaurantInfo>(response);

            // Assert
            Assert.That(locationResponse.Data[0].Name, Is.EqualTo("Johnson PLC"));
        }

        // TEST METHOD POST 
        [TestCase("steveadmin@test.com", "1", HttpStatusCode.OK, TestName = "Not found Non-name")]
        public void AutorizationTest(string email, string password, HttpStatusCode expectedHttpStatusCode)
        {
            // Arrange
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest("api/login", Method.POST);

            // Act
            IRestResponse response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

























































































































































































































        // Test by Volodymyr Swischo

        [Test]

        public void ComparisonCategoriesTest()
		{
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest("api/categories", Method.GET);

            IRestResponse response = client.Execute(request);

            CategoriesInfo locationResponse =
                new JsonDeserializer().
                Deserialize<CategoriesInfo>(response);

            Assert.That(locationResponse.Data[6].Name, Is.EqualTo("Meat"));
        }

        [Test]

        public void CreatingReustaurantTest()
		{
            string tokenStr2;
            tokenStr2 = OwnerLoginGetToken();

            var client = new RestClient("http://localhost:6543/api/user_restaurants");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", tokenStr2);
            var body = @"{
" + "\n" +
            @"""address"": ""restaurantTest"",
" + "\n" +
            @"""description"": ""fwejifwefejwi"",
" + "\n" +
            @"""markup"": ""{\""blocks\"":[{\""key\"":\""41i60\"",\""text\"":\""fewfewfwe\"",\""type\"":\""unstyled\"",\""depth\"":0,\""inlineStyleRanges\"":[],\""entityRanges\"":[],\""data\"":{}}],\""entityMap\"":{}}"",
" + "\n" +
            @"""name"": ""restaurantTest"",
" + "\n" +
            @"""phone"": ""8888888888888888888"",
" + "\n" +
            @"""tags"": [""vegetarian""]
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        public string OwnerLoginGetToken()
        {
            var client = new RestClient("http://localhost:6543/api/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
            @"    ""email"": ""earlmorrison@test.com"",
" + "\n" +
            @"    ""password"": ""1111""
" + "\n" +
            @"}";

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            LoginInfo locationResponse =
                new JsonDeserializer().
                Deserialize<LoginInfo>(response);

            string tkn = locationResponse.Data[0].Token;

            Console.WriteLine(tkn);

            return tkn;
        }

        [Test]
        public void AutorizationPOSTTest()
        {
            string tokenStr2;
            tokenStr2 = OwnerLoginGetToken();

            Console.WriteLine($"token2: {tokenStr2}");

            var client = new RestClient("http://localhost:6543/api/order/158");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", tokenStr2);
            var body = @"{" + "\n" +
            @"    ""item_id"": 1," + "\n" +
            @"    ""q_value"": 1" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
