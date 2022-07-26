namespace ADO.NETAddressBook;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select option\n1.Create AddrssBookServiceDatabase\n2.CreateTable\n3.InsertTntoTable\n" +
                        "4.RetriveAllContact\n5.UpdatingToExisting\n5.updateData\n6.DeletingThedata\n7.CountEmployeeByState&City"); 
        int op = Convert.ToInt16(Console.ReadLine());
        AddressBookModel model = new AddressBookModel();
        AddressBook addressBook = new AddressBook();

        switch (op)
        {
            case 1:
                addressBook.Create_Database();
                break;
            case 2:
                addressBook.CreateTable();
                break;
            case 3:

                model.FirstName = "Rohit";
                model.LastName = "Katariya";
                model.Address = "Main Market";
                model.City = "Dehli";
                model.State = "Dehli";
                model.Zip = "785264";
                model.PhoneNumber = "1254789630";
                model.Email = "Rohit@gmail.com";
                addressBook.AddContact(model);
                break;
            case 4:
                addressBook.RetriveAllContact();
                break;

            case 5:
                addressBook.updateEmployeeDetails();
                Console.WriteLine("Update SucsessFully");
                break;

            case 6:
                addressBook.DeletingTheContactUsingFirst();
                Console.WriteLine("Delete the data Sucessfully");
                break;

            case 7:
                int countCity = addressBook.CountOfEmployeeDetailsByCity();
                Console.WriteLine("Count of Records for given City :" + countCity);
                int CountState = addressBook.CountOfEmployeeDetailsByState();
                Console.WriteLine("Count of Records for given State :" + CountState);
                break;




        }
    }
}