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
    }
}
