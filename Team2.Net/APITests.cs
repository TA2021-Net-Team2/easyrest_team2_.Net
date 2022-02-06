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
        // Client 

        RestClient client = new RestClient("http://localhost:6543/");

        // tokens for users roles

        string tokenAdministrator = GetTokenLogin("eringonzales@test.com", "1");
        string tokenModerator = GetTokenLogin("petermoderator@test.com", "1");
        string tokenOwner = GetTokenLogin("earlmorrison@test.com", "1111");
        string tokenClient = GetTokenLogin("katherinebrennan@test.com", "1111");
        // Method for get token login

        public static string GetTokenLogin(string email, string password)
        {
            var client = new RestClient("http://localhost:6543/api/login");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
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

            string token = locationResponse.Data[0].Token;

            return token;
        }

        // *** API tests Bohdan Oleksiichuk ***

        [Test]
        public void CheckAPIRestaurantTest()
        {
            // Arrange
            RestRequest request = new RestRequest("api/restaurant", Method.GET);

            // Action 
            IRestResponse response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CheckTypeAPIRestaurantTest()
        {
            // arrange
            RestRequest request = new RestRequest("api/restaurant", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            //Check type json
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

        [TestCase("2", HttpStatusCode.OK, TestName = "ExistRestaurantTest")]
        [TestCase("123", HttpStatusCode.NotFound, TestName = "NonExistRestaurantTest")]
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
        public void CorrectRestaurantNameTest()
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
        public void ListOfWaitersWithOrdersTrueTest()  //LoginAdministrator
        {
            var request = new RestRequest("api/waiters?with_orders=True", Method.GET);

            request.AddHeader("X-Auth-Token", tokenAdministrator);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void BadAuthWithWrongeEmailTest()
        {
            var request = new RestRequest("api/login", Method.POST);

            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", "{\r\n\"email\": \" alexandriawright@test.com\",\r\n\"password\": \"1\"\r\n}", ParameterType.RequestBody);
            
            IRestResponse response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);

            Assert.That(obs["error"].ToString(), Is.EqualTo("Email or password is invalid"), "Email or password is invalid");
        }

        [Test]
        public void BadAuthForBlockedUserTest()
        {
            var request = new RestRequest("api/login", Method.POST);

            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/plain", "{\r\n\"email\": \"angelabrewer@test.com\",\r\n\"password\": \"1111\"\r\n}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);

            Assert.That(obs["error"].ToString(), Is.EqualTo("Sorry, you have been blocked"), "Sorry, you have been blocked");
        }

        [Test]
        public void AddNewUserRegistrationFromModeratorTest() //LoginModerator
        {
            var request = new RestRequest("api/user/1", Method.POST);

            request.AddHeader("X-Auth-Token", tokenModerator);
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

      // *** Made by Meleshchuk ***

        //GET

        [Test]
        public void CategoriesTest()
        {
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
            var request = new RestRequest("api/user/5", Method.POST);

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
        }

        //END by Meleshchuk

        // *** Tests by Volodymyr Swischo ***

        [Test]
        public void ComparisonCategoriesTest()
		{
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
            var request = new RestRequest("api/user_restaurants", Method.POST);

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

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
        // END

        // *** API autotests Yatsyna Denis ***
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

            //Console.WriteLine(response.Content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        // END tests;

        // *** API tests by Oleksandr ***

        // GET method
        [Test]
        public void ComparisonGetCategoriesTest()
        {
            RestRequest request = new RestRequest("api/categories", Method.GET);

            IRestResponse response = client.Execute(request);

            CategoriesInfo locationResponse =
                new JsonDeserializer().
                Deserialize<CategoriesInfo>(response);

            Assert.That(locationResponse.Data[5].Name, Is.EqualTo("Pizza"));
        }

        // POST method
        [Test]
        public void AddItemToOrderTest()
        {
            var request = new RestRequest("api/order/64", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-auth-token", tokenClient);
            var body = @"{" + "\n" +
            @"    ""item_id"": 20," + "\n" +
            @"    ""q_value"": 1" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        // END OF TESTS

    }
}
