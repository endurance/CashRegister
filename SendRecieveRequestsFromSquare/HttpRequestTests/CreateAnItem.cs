using System.Collections.Generic;
using System.Runtime.InteropServices;
using CashRegister.Core.Models;
using CashRegister.Infrastructure.SquareMessages;
using NUnit.Framework;
using RestSharp;
namespace SendRecieveRequestsFromSquare.HttpRequestTests
{
    [TestFixture]
    public class RequestsToSquareTester
    {

        public void SetHeaders(RestRequest request, string Access_Token)
        {
            // Standard header for square connect api requests
            request.AddHeader("Authorization", "Bearer " + Access_Token);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
        }
        [Test]
        public void CreateAnItem() 
        {

        }

        [Test]
        public void GetAllItems()
        {
            //Arrange
            const string Access_Token = "QY7A2IAniekH7j2oPb75_g";
            var getMessage = new GetAllMessage();
            var client = new RestClient(getMessage.EndPoint);
            var request = new RestRequest("/v1/" + "me" + "/items", Method.GET);

            //Act
            SetHeaders(request, Access_Token);
            var items = client.Execute<List<ItemList>>(request);

            //Assert
            //TODO: Need to make this test more robust by learning how to properly deserialize the reponse
            Assert.That(items.Data.Count > 0);
        }
    }
}