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

        //Made by Meleshchuk
        public string OwnerLoginGetToken2()
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

        //GET

        [Test]
        public void CategoriesTest()
        {
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest("api/categories", Method.GET);

            IRestResponse response = client.Execute(request);

            CategoriesInfo locationResponse =
                new JsonDeserializer().
                Deserialize<CategoriesInfo>(response);

            Assert.That(locationResponse.Data[1].Name, Is.EqualTo("Coctails"));
        }

        //POST

        [Test]
        public void CreateAdministratorTest()
        {
            string Token = OwnerLoginGetToken2();
            var client = new RestClient("http://localhost:6543/api/user/5");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", Token);
            string body = @"{
            " + "\n" +
            @"    ""birth_date"": ""2022-02-05T09:33:47.640Z"",
            " + "\n" +
            @"    ""email"": ""asf547dghdg@test.com"",
            " + "\n" +
            @"    ""name"": ""Ahmed"",
            " + "\n" +
            @"    ""password"": ""1234567813"",
            " + "\n" +
            @"    ""phone_number"": ""12345678901"",
            " + "\n" +
            @"    ""restaurant_id"": ""2""
            " + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
