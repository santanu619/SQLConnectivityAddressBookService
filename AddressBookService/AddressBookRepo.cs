using System;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookService
{
    public class ContactRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_Book;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllData()
        {
            try
            {
                Contact contact = new Contact();
                using (this.connection)
                {
                    string query = @"Select * from Address_Book;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            contact.ID = dr.GetInt32(0);
                            contact.FirstName = dr.GetString(1);
                            contact.LastName = dr.GetString(2);
                            contact.Address = dr.GetString(3);
                            contact.City = dr.GetString(4);
                            contact.State = dr.GetString(5);
                            contact.Zip = dr.GetString(6);
                            contact.PhoneNumber = dr.GetString(7);
                            contact.Email = dr.GetString(8);
                            contact.Type = dr.GetString(9);
                            System.Console.WriteLine(contact.ID + " " + contact.FirstName + " " + contact.LastName + " " + contact.Address + " " + contact.City + " " + contact.State + " " + contact.Zip + " " + contact.PhoneNumber + " " + contact.Email + " " + contact.Type);
                            System.Console.WriteLine("\n");
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found in the address book");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }


        public bool AddContact(Contact contact)
        {
            try
            {
                using (this.connection)
                {

                    SqlCommand command = new SqlCommand("SpAddContactDetail", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", contact.ID);
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    command.Parameters.AddWithValue("@Zip", contact.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.Parameters.AddWithValue("@Type", contact.Type);

                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
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
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public void UpdateContact(Contact contact, string firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = $"UPDATE contacts SET FirstName = '{contact.FirstName}', LastName = '{contact.LastName}', Address = '{contact.Address}', City = '{contact.City}', State = '{contact.State}', Zip = '{contact.Zip}', PhoneNumber = '{contact.PhoneNumber}', Email = '{contact.Email}',Type='{contact.Type}' WHERE FirstName = '{firstName}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Data Updated in the AddressBook.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void RemoveContact(String firstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = $"delete from contacts where FirstName = '{firstName}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Contact Deleted from AddressBook.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

    }
}