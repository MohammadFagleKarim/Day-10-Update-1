using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerDetailsInformation.Model;
using CustomerDetailsInformation.BLL;

namespace CustomerDetailsInformation
{
    public partial class CustomerUi : Form
    {
        CustomerManager _customerManager = new CustomerManager();

        public string Id;

        public CustomerUi()
        {
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();

            if (String.IsNullOrEmpty(customerCodeTextBox.Text))
            {
                MessageBox.Show("Code Can not be Empty!!!");
                return;
            }

            customers.CustomerCode = customerCodeTextBox.Text;

            customerDataGridView.DataSource = _customerManager.Search(customers);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();

            if (String.IsNullOrEmpty(customerCodeTextBox.Text))
            {
                MessageBox.Show("Code Can not be Empty!!!");
                return;
            }

            if (customerCodeTextBox.TextLength != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(customerAddressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(customerContactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }

            if (customerContactTextBox.TextLength != 11)
            {
                MessageBox.Show("Contact must be 11 digit!!!");
                return;
            }

            if (String.IsNullOrEmpty(districtComboBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }

            customers.CustomerName = customerNameTextBox.Text;
            customers.CustomerCode = customerCodeTextBox.Text;
            customers.Address = customerAddressTextBox.Text;
            customers.Contact = customerContactTextBox.Text;

            //Check UNIQUE

            if (_customerManager.IsCodeExists(customers))
            {
                MessageBox.Show(customerCodeTextBox.Text + " Already Exists!");
                return;
            }



            //Check UNIQUE

            if (_customerManager.IsContactExists(customers))
            {
                MessageBox.Show(customerContactTextBox.Text + " Already Exists!");
                return;
            }

            //add check

            bool isAdded = _customerManager.Save(customers);

            if (isAdded)
            {
                MessageBox.Show("Saved");
                
            }
            else

            {
                MessageBox.Show("Not Saved");
            }
        }   

        private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.customerDataGridView.Rows[e.RowIndex];
                Id = row.Cells[0].Value.ToString();
                customerCodeTextBox.Text = row.Cells[1].Value.ToString();
                customerNameTextBox.Text = row.Cells[2].Value.ToString();
                customerAddressTextBox.Text = row.Cells[3].Value.ToString();
                customerContactTextBox.Text = row.Cells[4].Value.ToString();
                customerDistrictComboBox.Text = row.Cells[5].Value.ToString();
            }
        }    }
}
