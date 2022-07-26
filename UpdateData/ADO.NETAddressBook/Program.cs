namespace ADO.NETAddressBook;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select option\n1.Create AddrssBookServiceDatabase\n2.CreateTable\n3.InsertTntoTable\n4.RetriveAllContact\n5.UpdatingToExisting");
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

                model.FirstName = "Luv";
                model.LastName = "Sahu";
                model.Address = "Sector 18";
                model.City = "Gurguram";
                model.State = "Harayana";
                model.Zip = "456079";
                model.PhoneNumber = "7894561230";
                model.Email = "Luv@gmail.com";
                addressBook.AddContact(model);
                break;
            case 4:
                addressBook.RetriveAllContact();
                break;

            case 5:
                addressBook.updateEmployeeDetails();
                Console.WriteLine("Update SucsessFully");
                break;



        }
    }
}