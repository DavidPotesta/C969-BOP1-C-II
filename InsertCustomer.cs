using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_BOP1_Potesta_David_001243829
{
    public partial class InsertCustomer : Form
    {
        public InsertCustomer()
        {
            InitializeComponent();
        }


        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            Customer customerInfo = new Customer();
            customerInfo.Name = txtInsertName.Text;
            customerInfo.Address = txtInsertAddress.Text;
            customerInfo.Address2 = txtInsertAddress2.Text;
            customerInfo.City = txtInsertCity.Text;
            customerInfo.Country = txtInsertCountry.Text;
            customerInfo.PostalCode = txtInsertPostal.Text; 
            customerInfo.Phone = txtInsertPhone.Text;

            DialogResult confirmInsert = MessageBox.Show("Are you sure that you want to add this customer?", "Confirm?", MessageBoxButtons.YesNo);
            if (confirmInsert == DialogResult.Yes)
            {

                bool result = Controller.insertCustomer(customerInfo);
                if (result)
                {
                    MessageBox.Show($"Customer: {customerInfo.Name} has been successfully added.");

                }
                else
                {
                    MessageBox.Show($"ERROR: Customer: {customerInfo.Name} has NOT been added.");
                }

                InsertCustomer insertCustomer = new InsertCustomer();
                insertCustomer.Show();
                this.Dispose(false);
            }
        }

        private void btnInsertExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
