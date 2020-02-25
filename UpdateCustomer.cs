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
    public partial class UpdateCustomer : Form
    {
        private int currentCustomerId;
        private int currentAddressId;
        private int currentCityId;
        private int currentCountryId;
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void btnUpdateCustomerSearch_Click(object sender, EventArgs e)
        {
            // Search On Customer and get customerId
            DataSet customerRecord = Controller.searchByCustomerName(txtUpdateSearch.Text.ToString());

            // Only continue if one and only one customer record was returned, or else break.
            try
            {
                var addressId = customerRecord.Tables[0].AsEnumerable().
                    Select(a => new { addressId = a.Field<int>("addressId") }).ToList();
                int useThisAddress = (int)addressId[0].GetType().GetProperty("addressId").GetValue(addressId[0], null);

                // Now use AddressId from Customer DS to retrieve and use address
                DataSet addressRecord = Controller.getAddressRecordByAddressId(useThisAddress);

                var cityId = addressRecord.Tables[0].AsEnumerable().
                    Select(a => new { cityId = a.Field<int>("cityId") }).ToList();
                int useThisCityID = (int)cityId[0].GetType().GetProperty("cityId").GetValue(cityId[0], null);

                //Now use cityId to retrieve city from Database
                DataSet cityRecord = Controller.getCityRecordByCityID(useThisCityID);

                var countryId = cityRecord.Tables[0].AsEnumerable().
                    Select(a => new { countryId = a.Field<int>("countryId") }).ToList();
                int useThisCountryID = (int)countryId[0].GetType().GetProperty("countryId").GetValue(countryId[0], null);

                DataSet countryRecord = Controller.getCountryRecordByCountryID(useThisCountryID);

                txtUpdateName.Text = customerRecord.Tables[0].Rows[0]["customerName"].ToString();
                txtUpdateAddress.Text = addressRecord.Tables[0].Rows[0]["address"].ToString();
                txtUpdateAddress2.Text = addressRecord.Tables[0].Rows[0]["address2"].ToString();
                txtUpdateCity.Text = cityRecord.Tables[0].Rows[0]["city"].ToString();
                txtUpdateCountry.Text = countryRecord.Tables[0].Rows[0]["country"].ToString();
                txtUpdatePostal.Text = addressRecord.Tables[0].Rows[0]["postalCode"].ToString();
                txtUpdatePhone.Text = addressRecord.Tables[0].Rows[0]["phone"].ToString();

                string customerID = customerRecord.Tables[0].Rows[0]["customerId"].ToString();
                int.TryParse(customerID, out currentCustomerId);
                currentAddressId = useThisAddress;
                currentCityId = useThisCityID;
                currentCountryId = useThisCountryID;

            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Your search could not be completed.  Please alter your search and try again. (No results or multiple results found)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a general error.");
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            Customer customerInfo = new Customer();
            customerInfo.Name = txtUpdateName.Text;
            customerInfo.Address = txtUpdateAddress.Text;
            customerInfo.Address2 = txtUpdateAddress2.Text;
            customerInfo.City = txtUpdateCity.Text;
            customerInfo.Country = txtUpdateCountry.Text;
            customerInfo.PostalCode = txtUpdatePostal.Text;
            customerInfo.Phone = txtUpdatePhone.Text;
            customerInfo.countryId = currentCountryId;
            customerInfo.cityId = currentCityId;
            customerInfo.addressId = currentAddressId;
            customerInfo.customerId = currentCustomerId;
            
            DialogResult confirmInsert = MessageBox.Show("Are you sure that you want to update this customer?", "Confirm?", MessageBoxButtons.YesNo);
            if (confirmInsert == DialogResult.Yes)
            {

                bool result = Controller.updateCustomer(customerInfo);
                if (result)
                {
                    MessageBox.Show($"Customer: {customerInfo.Name} has been successfully updated.");
                }
                else
                {
                    MessageBox.Show($"ERROR: Customer: {customerInfo.Name} has NOT been updated.");
                }

                UpdateCustomer updateCustomer = new UpdateCustomer();
                updateCustomer.Show();
                this.Dispose(false);
            }
        }

        private void btnUpdateExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
