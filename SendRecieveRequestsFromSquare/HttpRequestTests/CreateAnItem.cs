using System.Collections.Generic;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.SquareMessages;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Utilities;

namespace SendRecieveRequestsFromSquare.HttpRequestTests
{
    [TestFixture]
    public class RequestsToSquareTester
    {
        const string TestItemId = "af881f06-c3dd-4c74-94d6-58358fb1a8ea";
        const string AccessToken = "DUxLfvEGFS2CAuW0J1CZ1Q";
        public void SetHeaders(RestRequest request)
        {
            // Standard header for square connect api requests
            request.AddHeader("Authorization", "Bearer " + AccessToken);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
        }

        [Test]
        public void GetOneItem_Deserialize()
        {
            //Arrange
            var getMessage = new GetAllMessage();
            var client = new RestClient(getMessage.EndPoint);

            var request = new RestRequest("/v1/" + "me" + "/items/" + TestItemId, Method.GET);
            SetHeaders(request);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            //Act
            var response = client.Execute(request);

            var jsonD = new JsonDeserializer();

            Item item = jsonD.Deserialize<Item>(response);
            //Assert
            //TODO: Need to make this test more robust by learning how to properly deserialize the reponse
            Assert.That(item != null);
        }
        [Test]
        public void GetOneItem_Execute()
        {
            //Arrange
            var getMessage = new GetAllMessage();
            var client = new RestClient(getMessage.EndPoint);

            var request = new RestRequest("/v1/" + "me" + "/items/" + TestItemId, Method.GET);
            SetHeaders(request);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            //Act
            var item = client.Execute<Item>(request);
            //Assert
            //TODO: Need to make this test more robust by learning how to properly deserialize the reponse
            Assert.That(item.Data != null);
        }
    }
}