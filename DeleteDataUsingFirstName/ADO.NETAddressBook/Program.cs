namespace ADO.NETAddressBook;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select option\n1.Create AddrssBookServiceDatabase\n2.CreateTable\n3.InsertTntoTable\n" +
                        "4.RetriveAllContact\n5.UpdatingToExisting\n5.updateData\n6.DeletingThedata"); int op = Convert.ToInt16(Console.ReadLine());
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

                model.FirstName = "Suraj";
                model.LastName = "Gupta";
                model.Address = "Sector 18";
                model.City = "Gurguram";
                model.State = "Harayana";
                model.Zip = "547896";
                model.PhoneNumber = "4568791238";
                model.Email = "Suraj@gmail.com";
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



        }
    }
}