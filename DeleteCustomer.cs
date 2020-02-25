using MySql.Data.MySqlClient;
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
    public partial class DeleteCustomer : Form
    {

        private int currentCustomerId;
        private int currentAddressId;
        private int currentCityId;
        private int currentCountryId;
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void btnDeleteCustomerSearch_Click(object sender, EventArgs e)
        {
            // Search On Customer and get customerId
            DataSet customerRecord = Controller.searchByCustomerName(txtDeleteSearch.Text.ToString());

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

                txtDeleteName.Text = customerRecord.Tables[0].Rows[0]["customerName"].ToString();
                txtDeleteAddress.Text = addressRecord.Tables[0].Rows[0]["address"].ToString();
                txtDeleteAddress2.Text = addressRecord.Tables[0].Rows[0]["address2"].ToString();
                txtDeleteCity.Text = cityRecord.Tables[0].Rows[0]["city"].ToString();
                txtDeleteCountry.Text = countryRecord.Tables[0].Rows[0]["country"].ToString();
                txtDeletePostal.Text = addressRecord.Tables[0].Rows[0]["postalCode"].ToString();
                txtDeletePhone.Text = addressRecord.Tables[0].Rows[0]["phone"].ToString();

                string customerID = customerRecord.Tables[0].Rows[0]["customerId"].ToString();
                int.TryParse(customerID, out currentCustomerId);
                currentAddressId = useThisAddress;
                currentCityId = useThisCityID;
                currentCountryId = useThisCountryID;

            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show("Your search could not be completed.  Please alter your search and try again. (No results or multiple results found)");
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was a general error.");
            }
            

            
        }

        private void btnDeleteExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {

            DialogResult confirmDelete = MessageBox.Show("Are you sure that you want to delete this user?", "Confirm?", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {

                bool result = Controller.deleteCustomer(currentCustomerId,currentAddressId,currentCityId,currentCountryId);
                if(result)
                {
                    MessageBox.Show($"User: {currentCustomerId} has been successfully deleted.");
                }
                else
                {
                    MessageBox.Show($"ERROR: User: {currentCustomerId} has NOT been deleted.");
                }

                DeleteCustomer deleteCustomer = new DeleteCustomer();
                deleteCustomer.Show();
                this.Dispose(false);
            }


        }

    }
}
