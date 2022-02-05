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
        RestClient client = new RestClient("http://localhost:6543/");

        [Test]
        public void StatusCodeTest()
        {
            // Arrange
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

//------------------------------------------------Start Anna----------------------------------------------------------

        [Test]
        public void ListOfWaitersWithOrdersTrue()  //LoginAdministrator
        {
            var client = new RestClient("http://localhost:6543/");
            var request = new RestRequest("api/waiters?with_orders=True", Method.GET);

            request.AddHeader("X-Auth-Token", "nQ1n10fTQxBCRDtfu5L7cHdwbDPkmV5tRFGYg20z2DVXklnco5wMhNwvogLaI2VS7LWqjfHCRCPlwjQ12rud5D");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void BadAuthWithWrongeEmail()
        {
            //var client = new RestClient("http://localhost:6543/api/login");
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
        public string GetTokenLogin(string email, string password)
        {
            var client = new RestClient("http://localhost:6543/api/login");
            //client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            //var body = @"{" + "\n" + @" ""email"": ""petermoderator@test.com""," + "\n" + @"  ""password"": ""1""" + "\n" +  @"}";
            var body = @"{" + "\n" +
            @$"    ""email"": ""{email}"",
" + "\n" +
            @$"    ""password"": ""{password}""
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
            public void AddNewUserRegistrationFromModerator() //LoginModerator
        {
            string tokenStr2;
            tokenStr2 = GetTokenLogin("petermoderator@test.com", "1");

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

            string clientid = locationResponse.Data[0].Id;

            Console.WriteLine(clientid);

            //return clientid;

        }

        /*[Test]
        public void DeletedUserThatWasRegistrationFromModerator() //LoginModerator
        {

            string clientId;
            clientId = AddNewUserRegistrationFromModerator();

            string tokenStr2;
            tokenStr2 = GetTokenLogin("petermoderator@test.com", "1");

            Console.WriteLine($"token2: {tokenStr2}");

            var client = new RestClient($"http://localhost:6543/api/user/{clientId}"); //

            var request = new RestRequest(Method.DELETE);
            request.AddHeader("X-Auth-Token", tokenStr2);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", "{\r\n    \"name\": \"Elison Parker\",\r\n    \"email\": \"elison@parker.com\",\r\n    \"password\": \"11111111\",\r\n    \"phone_number\": \"8000000-\",\r\n    \"birth_date\": \"10-12-12\"\r\n}", ParameterType.RequestBody); IRestResponse response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.That(obs["message"].ToString(), Is.EqualTo("User successfully deleted"), "User successfully deleted");

        }*/

        //------------------------------------------------End Anna----------------------------------------------------------

      //Made by Meleshchuk

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
            string tokenOwner = GetTokenLogin("earlmorrison@test.com", "1111");

            var client = new RestClient("http://localhost:6543/api/user/5");

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", tokenOwner);
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

        //END by Meleshchuk

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
            string tokenOwner;

            tokenOwner = GetTokenLogin("earlmorrison@test.com", "1111");

            var client = new RestClient("http://localhost:6543/api/user_restaurants");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", tokenOwner);
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

        [Test]
        public void AutorizationPOSTTest()
        {
            string tokenOwner;

            tokenOwner = GetTokenLogin("earlmorrison@test.com", "1111");

            Console.WriteLine($"token2: {tokenOwner}");

            var client = new RestClient("http://localhost:6543/api/order/158");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", tokenOwner);
            var body = @"{" + "\n" +
            @"    ""item_id"": 1," + "\n" +
            @"    ""q_value"": 1" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        // END



        // API autotests Yatsyna Denis
        [Test]
        public void AutorizationTest()
        {
            // Arrange
            RestRequest request = new RestRequest("api/login", Method.POST);

            request.AddParameter("application/json",
                "{\"email\":\"steveadmin@test.com\",\"password\":\"1\"}",
                ParameterType.RequestBody);
            // Act
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Order_by_id_check()
        {
            RestRequest request = new RestRequest("", Method.POST);

            request.AddParameter("application/json",
               "{\"email\":\"steveadmin@test.com\",\"password\":\"1\"}",
               ParameterType.RequestBody);
        }

        // END tests;

        // API tests by Oleksandr 

        [Test]
        public void AddNewRestourant()

        {
            var client = new RestClient("http://localhost:6543/api/user_restaurants");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", "lTHtlnhvq6xPElfcVkFGRDtINaAnIt91QWbCnAFE420ru5nb17ImXWBzogPa1n88kW07hqX5lVdCVFhtbt4kXf");
            var body = @"{
            " + "\n" +
            @"    ""address"": ""OwnerD1"",
            " + "\n" +
            @"    ""description"": ""OwnerD1"",
            " + "\n" +
            @"    ""markup"": ""{\""blocks\"":[{\""key\"":\""3k1l9\"",\""text\"":\""123123123\"",\""type\"":\""unstyled\"",\""depth\"":0,\""inlineStyleRanges\"":[],\""entityRanges\"":[],\""data\"":{}}],\""entityMap\"":{}}"",
            " + "\n" +
             @"    ""name"": ""OwnerD1"",
            " + "\n" +
             @"    ""phone"": ""123111111"",
            " + "\n" +
            @"    ""tags"": [""beer""]
            " + "\n" +
             @"}";

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);
        }

        [Test]
        public void ComparisonGetCategoriesTest()
        {
            RestClient client = new RestClient("http://localhost:6543/");
            RestRequest request = new RestRequest("api/categories", Method.GET);

            IRestResponse response = client.Execute(request);

            CategoriesInfo locationResponse =
                new JsonDeserializer().
                Deserialize<CategoriesInfo>(response);

            Assert.That(locationResponse.Data[5].Name, Is.EqualTo("Pizza"));
        }
        // END OF TESTS
    }
}
