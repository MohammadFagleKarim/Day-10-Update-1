using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CustomerDetailsInformation.Model;

namespace CustomerDetailsInformation.Repository
{
    public class CustomerRepository
    {
        public List<Customers> Search(Customers customers)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Customers WHERE CustomerCode = '" + customers.CustomerCode + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, conn);

            //Open
            conn.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customers> customerss = new List<Customers>();

            while (sqlDataReader.Read())
            {
                //customerA.Code = sqlDataReader["Code"].ToString();
                customers.CustomerName = sqlDataReader["CustomerName"].ToString();
                customers.Address = sqlDataReader["Address"].ToString();
                customers.Contact = sqlDataReader["Contact"].ToString();

                customerss.Add(customers);
            }
            //Close
            conn.Close();

            //return dataTable;
            return customerss;
        }

        public bool Save(Customers customers)
        {
            bool isAdded = false;
            //Connection
            string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            //Command
            //INSERT INTO Customer (Code,Name, Address,Contact) Values (0001,'Arafat', 'Mirpur-13','01625420852')
            string commandString = @"INSERT INTO Customers (CustomerCode, CustomerName, Address, Contact, DistrictId) Values ('" + customers.CustomerCode + "', '" + customers.CustomerName + "', '" + customers.Address + "', '" + customers.Contact + "', '" + customers.DistrictId + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, conn);

            //Open
            conn.Open();

            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                isAdded = true;
            }

            //Close
            conn.Close();
            return isAdded;
        }

        public bool IsCodeExists(Customers customers)
        {
            bool exists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Customers WHERE CustomerCode = '" + customers.CustomerCode + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, conn);

            //Open
            conn.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }

            //Close
            conn.Close();
            return exists;
        }

        public bool IsContactExists(Customers customers)
        {
            bool exists = false;

            //Connection
            string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120) 
            string commandString = @"SELECT * FROM Customers WHERE Contact='" + customers.Contact + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, conn);

            //Open
            conn.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }

            //Close
            conn.Close();
            return exists;
        }

        public List<District> DistrictComboBox()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)

            string commandString = @"SELECT DisId, DistrictName FROM District";
            SqlCommand sqlCommand = new SqlCommand(commandString, conn);

            //Open
            conn.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<District> districts = new List<District>();

            while (sqlDataReader.Read())
            {
                District district = new District();
                district.DisId = Convert.ToInt32(sqlDataReader["DisId"]);
                district.DistrictName = sqlDataReader["DistrictName"].ToString();

                districts.Add(district);
            }

            //Close
            conn.Close();

            //return dataTable;
            return districts;
        }

        //public bool CustomersAdd(Customers customers)
        //{
        //    bool IsAdded = false;

        //    try
        //    {
        //        //Connection
        //        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
        //        SqlConnection conn = new SqlConnection(connectionString);

        //        //Command
        //        string commandString = @"INSERT INTO Customers (CustomerCode, CustomerName, Address, Contact, DistrictId) VALUES ('" + customers.CustomerCode + "', '" + customers.CustomerName + "', '" + customers.Address + "', '" + customers.Contact + "', '" + customers.DistrictId + "')";
        //        SqlCommand sqlCommand = new SqlCommand(commandString, conn);

        //        //Execute
        //        conn.Open();

        //        int isExecuted = sqlCommand.ExecuteNonQuery();
        //        if (isExecuted > 0)
        //        {
        //            IsAdded = true;
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }

        //    return IsAdded;
        //}

        //public bool IsCustomerCodeExist(Customers customers)
        //{
        //    bool exist = false;

        //    //Connection

        //    string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    //Command

        //    string commandString = @"SELECT * FROM Customers WHERE CustomerCode ='" + customers.CustomerCode + "' ";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, conn);

        //    //Open

        //    conn.Open();

        //    //Execute

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    // showdataGridView.DataSource = dataTable;

        //    if (dataTable.Rows.Count > 0)
        //    {
        //        exist = true;
        //    }

        //    //Close

        //    conn.Close();

        //    return exist;
        //}

        //public bool IsContactExist(Customers customers)
        //{
        //    bool exist = false;

        //    //Connection

        //    string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    //Command

        //    string commandString = @"SELECT * FROM Customers WHERE Contact ='" + customers.Contact + "' ";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, conn);

        //    //Open

        //    conn.Open();

        //    //Execute

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    // showdataGridView.DataSource = dataTable;

        //    if (dataTable.Rows.Count > 0)
        //    {
        //        exist = true;
        //    }

        //    //Close

        //    conn.Close();

        //    return exist;
        //}

        //public bool CustomersDelete(Customers customers)
        //{
        //    bool isdeleted = false;

        //    //Connection

        //    string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    //Command

        //    string commandString = @"DELETE FROM Customers where CustomerId = '" + customers.CustomerId + "' ";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, conn);

        //    //Open

        //    conn.Open();

        //    //Execute

        //    int isExucuted = sqlCommand.ExecuteNonQuery();

        //    if (isExucuted > 0)
        //    {
        //        isdeleted = true;
        //    }

        //    //Close

        //    conn.Close();

        //    return isdeleted;
        //}

        //public bool CustomersUpdate(Customers customers)
        //{
        //    bool isupdate = false;

        //    //Connection

        //    string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    //Command

        //    string commandString = @"UPDATE Customers SET CustomerCode = '" + customers.CustomerCode + "', CustomerName='" + customers.CustomerName + "', Address = '" + customers.Address + "', Contact = '" + customers.Contact + "', District = '" + customers.District + "' WHERE CustomerId = '" + customers.CustomerId + "' ";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, conn);

        //    //Open

        //    conn.Open();

        //    //Execute

        //    int isexecute = sqlCommand.ExecuteNonQuery();

        //    if (isexecute > 0)
        //    {
        //        isupdate = true;
        //    }

        //    //Close

        //    conn.Close();

        //    return isupdate;
        //}

        //public List<Customers> Display()
        //{
        //    //Connection

        //    string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    //Command

        //    string commandString = @"SELECT * FROM Customers";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, conn);

        //    //Open

        //    conn.Open();

        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //    List<Customers> customers = new List<Customers>();

        //    while (sqlDataReader.Read())
        //    {
        //        Customers customer = new Customers();
        //        customer.CustomerId = Convert.ToInt32(sqlDataReader["CustomerId"]);
        //        customer.CustomerCode = sqlDataReader["CustomerCode"].ToString();
        //        customer.CustomerName = sqlDataReader["CustomerName"].ToString();
        //        customer.Address = sqlDataReader["Address"].ToString();
        //        customer.Contact = sqlDataReader["Contact"].ToString();
        //        customer.District = sqlDataReader["District"].ToString();

        //        customers.Add(customer);
        //    }

        //    //Execute

        //    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //    //DataTable dataTable = new DataTable();
        //    //sqlDataAdapter.Fill(dataTable);
        //    //showdataGridView.DataSource = dataTable;

        //    //if (dataTable.Rows.Count > 0)
        //    //{
        //    //    //showdataGridView.DataSource = dataTable;
        //    //}

        //    //else
        //    //{
        //    //    //MessageBox.Show("Data Tabel not found");
        //    //}

        //    //Close

        //    conn.Close();

        //    return customers;
        //}

        //public DataTable Search(Customers customers)
        //{
        //    //Connection

        //    string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; DataBase=CustomerDetailsInfo; Integrated Security=True";
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    //Command

        //    string commandString = @"SELECT * FROM Customers WHERE CustomerName ='" + customers.CustomerName + "'";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, conn);

        //    //Open

        //    conn.Open();

        //    //Execute

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);
        //    // showdataGridView.DataSource = dataTable;

        //    //if (dataTable.Rows.Count > 0)
        //    //{
        //    //    showdataGridView.DataSource = dataTable;
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Data Tabel not found");

        //    //}

        //    //Close

        //    conn.Close();

        //    return dataTable;
        //}
    }
}
