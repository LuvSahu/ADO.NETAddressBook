namespace ADO.NETAddressBook;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to AddressBook ADO.NET!");
        Console.WriteLine("Select option\n1)Create AddrssBookServiceDatabase");
        int op = Convert.ToInt16(Console.ReadLine());
        AddressBook addressBook= new AddressBook();

        switch (op)
        {
            case 1:
                addressBook.Create_Database();
                break;

        }
    }
}