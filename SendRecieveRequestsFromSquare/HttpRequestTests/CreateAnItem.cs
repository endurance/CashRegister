using System.Runtime.InteropServices;
using CashRegister.Infrastructure.SquareMessages;
using NUnit.Framework;
using RestSharp;
namespace SendRecieveRequestsFromSquare.HttpRequestTests
{
    [TestFixture]
    public class RequestsToSquareTester
    {


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

            //Act
            var client = new RestClient(getMessage.EndPoint);

            var request = new RestRequest("/v1/" + Access_Token + "/items", Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            //Assert
            Assert.IsNotNull(content);  //Currently a false positive due to a "Not Authorized" response...
        }
    }
}