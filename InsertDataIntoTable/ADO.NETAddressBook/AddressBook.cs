using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NETAddressBook
{
    internal class AddressBook
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Addressbook_ADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void Create_Database()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Addressbook_ADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                Connection.Open();
                SqlCommand command = new SqlCommand("Create database Addressbook_ADO;", Connection);
                command.ExecuteNonQuery();
                Console.WriteLine("AddressbookService Database created successfully!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateTable()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Addressbook_ADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                Connection.Open();
                SqlCommand command = new SqlCommand("Create table AddressBooks(id int identity(1,1)primary key,FirstName varchar(200),LastName varchar(200),Address varchar(200), City varchar(200), State varchar(200), Zip varchar(200), PhoneNumber varchar(50), Email varchar(200)); ", Connection);
                command.ExecuteNonQuery();
                Console.WriteLine("AddressBook table has been created successfully!");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool AddContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("SpAddressBooks", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@State", model.State);
                    cmd.Parameters.AddWithValue("@Zip", model.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", model.Email);


                    this.connection.Open();

                    var result = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

    }  
}
