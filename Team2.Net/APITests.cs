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
        [TestCase("steveadmin@test.com", "1", HttpStatusCode.OK, TestName = "Hello")]
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

//------------------------------------------------Start Anna----------------------------------------------------------

        [Test]
        public void ListOfWaitersWithOrdersTrue()  //LoginAdministrator
        {
            var client = new RestClient("http://localhost:6543/api/waiters?with_orders=True");
            var request = new RestRequest(Method.GET);

            request.AddHeader("X-Auth-Token", "nQ1n10fTQxBCRDtfu5L7cHdwbDPkmV5tRFGYg20z2DVXklnco5wMhNwvogLaI2VS7LWqjfHCRCPlwjQ12rud5D");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void BadAuthWithWrongeEmail()
        {
            var client = new RestClient("http://localhost:6543/api/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/plain");

            request.AddParameter("text/plain", "{\r\n\"email\": \" alexandriawright@test.com\",\r\n\"password\": \"1\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.That(obs["error"].ToString(), Is.EqualTo("Email or password is invalid"), "Email or password is invalid");

        }

        [Test]
        public void BadAuthForBlockedUser()
        {
            var client = new RestClient("http://localhost:6543/api/login");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", "{\r\n\"email\": \"katherinebrennan@test.com\",\r\n\"password\": \"1111\"\r\n}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.That(obs["error"].ToString(), Is.EqualTo("Sorry, you have been blocked"), "Sorry, you have been blocked");

        }



       // [OneTimeSetUp]
        public string ModeratorLoginGetToken()
        {
            var client = new RestClient("http://localhost:6543/api/login");
            //client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            //var body = @"{" + "\n" + @" ""email"": ""petermoderator@test.com""," + "\n" + @"  ""password"": ""1""" + "\n" +  @"}";
            var body = @"{" + "\n" +
            @"    ""email"": ""petermoderator@test.com"",
" + "\n" +
            @"    ""password"": ""1""
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

       // [Test]
            public string AddNewUserRegistrationFromModerator() //LoginModerator
        {
            string tokenStr2;
            tokenStr2 = ModeratorLoginGetToken();

            Console.WriteLine($"token2: {tokenStr2}");

            var client = new RestClient("http://localhost:6543/api/user/1");
            var request = new RestRequest(Method.POST);
            request.AddHeader("X-Auth-Token", tokenStr2);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n \"name\": \"Elison Potter\",\r\n\"email\": \"elison@potter.com\",\r\n \"password\": \"11111111\",\r\n\"phone_number\": \"80000002\",\r\n    \"birth_date\": \"11-10-11\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.That(obs["message"].ToString(), Is.EqualTo("User successfully added"), "User successfully added");

            //Get user with id =55 Data.id
            ClientInfo locationResponse =
                new JsonDeserializer().
                Deserialize<ClientInfo>(response);

            string clientid = locationResponse.Data[0].id;

            Console.WriteLine(clientid);

            return clientid;


        }

        [Test]
        public void DeletedUserThatWasRegistrationFromModerator() //LoginModerator
        {

            string clientId;
            clientId = AddNewUserRegistrationFromModerator();

            string tokenStr2;
            tokenStr2 = ModeratorLoginGetToken();

            Console.WriteLine($"token2: {tokenStr2}");

            var client = new RestClient($"http://localhost:6543/api/user/{clientId}"); //

            var request = new RestRequest(Method.DELETE);
            request.AddHeader("X-Auth-Token", tokenStr2);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", "{\r\n    \"name\": \"Elison Parker\",\r\n    \"email\": \"elison@parker.com\",\r\n    \"password\": \"11111111\",\r\n    \"phone_number\": \"8000000-\",\r\n    \"birth_date\": \"10-12-12\"\r\n}", ParameterType.RequestBody); IRestResponse response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.That(obs["message"].ToString(), Is.EqualTo("User successfully deleted"), "User successfully deleted");

        }
        //------------------------------------------------End Anna----------------------------------------------------------

    }
}
