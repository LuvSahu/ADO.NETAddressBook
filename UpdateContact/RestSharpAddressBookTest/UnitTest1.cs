using Newtonsoft.Json;
using OfficeDevPnP.Core.UPAWebService;
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

        [Test]
        public void GivenMultipleEmployee_OnPost_ThenShouldReturnEmployeeList()
        {
            List<AddressBook> contactList = new List<AddressBook>();
            contactList.Add(new AddressBook { FirstName = "Rohit", LastName = "Katariya", PhoneNumber = "8877456345", Address = "Katla Mohalla", City = "Ajmer", State = "Rajasthan", Zip = "147677", Email = "rohit@gmail.com" });
            contactList.Add(new AddressBook { FirstName = "Rishi", LastName = "Dutt", PhoneNumber = "7356456345", Address = "Bhagat Singh", City = "Alwar", State = "Rajasthan", Zip = "247677", Email = "rishi@gmail.com" });
            contactList.Add(new AddressBook { FirstName = "Sachin", LastName = "Kumar", PhoneNumber = "6577456345", Address = "Bhakhwat Chowk", City = "Gurugram", State = "Haryana", Zip = "347677", Email = "sachin@gmail.com" });
            contactList.Add(new AddressBook { FirstName = "Honey", LastName = "Singh", PhoneNumber = "57577456345", Address = "Manesar", City = "Ahemdabad", State = "Gujarat", Zip = "447677", Email = "honey@gmail.com" });
            foreach (var ContactData in contactList)
            {
                RestRequest request = new RestRequest("/AddressBook", Method.Post);
                JsonObject jObjectBody = new JsonObject();
                jObjectBody.Add("FirstName", ContactData.FirstName);
                jObjectBody.Add("LastName", ContactData.LastName);
                jObjectBody.Add("PhoneNumber", ContactData.PhoneNumber);
                jObjectBody.Add("Address", ContactData.Address);
                jObjectBody.Add("City", ContactData.City);
                jObjectBody.Add("State", ContactData.State);
                jObjectBody.Add("Zip", ContactData.Zip);
                jObjectBody.Add("Email", ContactData.Email);
                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                RestResponse response1 = client.Execute(request);
                Assert.AreEqual(response1.StatusCode, HttpStatusCode.Created);
                AddressBook dataResorce1 = JsonConvert.DeserializeObject<AddressBook>(response1.Content);
                Assert.AreEqual(ContactData.FirstName, dataResorce1.FirstName);
                Assert.AreEqual(ContactData.LastName, dataResorce1.LastName);
                Assert.AreEqual(ContactData.PhoneNumber, dataResorce1.PhoneNumber);
                Assert.AreEqual(ContactData.Address, dataResorce1.Address);
                Assert.AreEqual(ContactData.City, dataResorce1.City);
                Assert.AreEqual(ContactData.State, dataResorce1.State);
                Assert.AreEqual(ContactData.Zip, dataResorce1.Zip);
                Assert.AreEqual(ContactData.Email, dataResorce1.Email);
                System.Console.WriteLine(response1.Content);
            };

            RestResponse response = getAddressList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<AddressBook> dataResorce = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
            Assert.AreEqual(6, dataResorce.Count);
        }

        [Test]
        public void GivenEmployee_WhenUpdateSalary_ThenShouldReturnUpdatedEmployeeSalary()
        {
            RestRequest request = new RestRequest("/AddressBook/4", Method.Put);
            JsonObject jObjectBody = new JsonObject();
            jObjectBody.Add("FirstName", "Suraj");
            jObjectBody.Add("LastName", "Gupta");
            jObjectBody.Add("PhoneNumber", "91000654344");
            jObjectBody.Add("Address", "Sector 18");
            jObjectBody.Add("City", "Gurgaon");
            jObjectBody.Add("State", "Harayana");
            jObjectBody.Add("Zip", "123456");
            jObjectBody.Add("email", "suraj@gmail.com");
            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            AddressBook dataResorce = JsonConvert.DeserializeObject<AddressBook>(response.Content);
            Assert.AreEqual("Suraj", dataResorce.FirstName);
            Assert.AreEqual("Gupta", dataResorce.LastName);
            Assert.AreEqual("91000654344", dataResorce.PhoneNumber);
            Assert.AreEqual("Sector 18", dataResorce.Address);
            Assert.AreEqual("Gurgaon", dataResorce.City);
            Assert.AreEqual("Harayana", dataResorce.State);
            Assert.AreEqual("789456", dataResorce.Zip);
            Assert.AreEqual("suraj@gmail.com", dataResorce.Email); ;
            Console.WriteLine(response.Content);
        }
    }
}