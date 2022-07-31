using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json.Nodes;

namespace RestSharpAddressBookTest
{
    public class AddressBook
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }


    }
    public class RestSharpAddrssBookTests
    {
        RestClient client;
        [SetUp]
        public void Setup()
        {
            client = new RestClient("http://localhost:5000");
        }
        private RestResponse getAddressList()
        {
            RestRequest request = new RestRequest("/AddressBook", Method.Get);

            RestResponse response = client.Execute(request);
            return response;
        }

        [Test]
        public void OnCallingGETApi_ReturnAddressBookList()
        {
            RestResponse response = getAddressList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<AddressBook> dataResponse = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);

            foreach (AddressBook addressBook in dataResponse)
            {
                System.Console.WriteLine("id: " + addressBook.Id + ",FirstName: " + addressBook.FirstName + ",LastName: " + addressBook.LastName + ",Address" + addressBook.Address + ",Ciyt" + addressBook.City + ",State" + addressBook.State + ",Phonenumber" + addressBook.PhoneNumber + ",Zip" + addressBook.Zip + ",Email" + addressBook.Email);
            }
        }

        [Test]
        public void givenContacts_OnPost_ShouldReturnAddedAddressBook()
        {
            RestRequest request = new RestRequest("/AddressBook", Method.Post);
            JsonObject jObjectbody = new JsonObject();
            jObjectbody.Add("FirstName", "Shubham");
            jObjectbody.Add("LastName", "Pandey");
            jObjectbody.Add("PhoneNumber", "7894561235");
            jObjectbody.Add("Address", "Godra");
            jObjectbody.Add("City", "Lucknow");
            jObjectbody.Add("State", "Up");
            jObjectbody.Add("Zip", "123456");
            jObjectbody.Add("email", "shubham@gmail.com");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            AddressBook dataResponse = JsonConvert.DeserializeObject<AddressBook>(response.Content);
            Assert.AreEqual("Shubham", dataResponse.FirstName);
            Assert.AreEqual("Pandey", dataResponse.LastName);
            Assert.AreEqual("7894561235", dataResponse.PhoneNumber);
            Assert.AreEqual("Godra", dataResponse.Address);
            Assert.AreEqual("Lucknow", dataResponse.City);
            Assert.AreEqual("Up", dataResponse.State);
            Assert.AreEqual("123456", dataResponse.Zip);
            Assert.AreEqual("shubham@gmail.com", dataResponse.Email);

        }
    }
}