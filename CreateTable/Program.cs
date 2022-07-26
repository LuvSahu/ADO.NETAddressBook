namespace ADO.NETAddressBook;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select option\n1.Create AddrssBookServiceDatabase\n2.CreateTable");
        int op = Convert.ToInt16(Console.ReadLine());
        AddressBook addressBook = new AddressBook();

        switch (op)
        {
            case 1:
                addressBook.Create_Database();
                break;
            case 2:
                addressBook.CreateTable();
                break;

        }
    }
}