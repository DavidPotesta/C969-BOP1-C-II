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
    public partial class UpdateAppointment : Form
    {
        private List<Object> _singleAppointment;
        private readonly AppointmentMain main1;
        private DataSet _singleCustomer;
        private DataSet _singleAddress;
        private DataSet _singleCity;
        private DataSet _singleCountry;

        public UpdateAppointment(List<Object> singleAppt, AppointmentMain appointmentMain)
        {
            InitializeComponent();
            main1 = appointmentMain;
            _singleAppointment = singleAppt;
            _singleCustomer = Controller.searchByCustomerId(int.Parse(singleAppt[1].ToString()));
            _singleAddress = Controller.getAddressRecordByAddressId(int.Parse(_singleCustomer.Tables[0].Rows[0]["AddressId"].ToString()));
            _singleCity = Controller.getCityRecordByCityID(int.Parse(_singleAddress.Tables[0].Rows[0]["CityId"].ToString()));
            _singleCountry = Controller.getCountryRecordByCountryID(int.Parse(_singleCity.Tables[0].Rows[0]["CountryId"].ToString()));
            dtStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            fillInAllFields();


        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            if (!Controller.ValidateTextBoxes(this))
            {
                return;
            }
            if (!Controller.ValidateDateTime(dtStart, dtEnd))
            {
                return;
            }
            main1.updateCalled = false;
            _singleAppointment[2] = txtAppointmentTitle.Text;

            _singleAppointment[6] = txtAppointmentType.Text;
            _singleAppointment[3] = txtAppointmentDescription.Text;
            _singleAppointment[4] = txtAppointmentLocation.Text;
            _singleAppointment[7] = txtAppointmentURL.Text;
            _singleAppointment[5] = txtAppointmentContact.Text;
            _singleAppointment[8] = dtStart.Value.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
            _singleAppointment[9] = dtEnd.Value.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");

            bool result = Controller.updateAppointment(_singleAppointment);
            if (result)
            {
                main1.RefreshGrid();
                MessageBox.Show("This appointment has been successfully updated.");
            }
            else
            {
                MessageBox.Show("This appointment has NOT been updated.");
            }

            this.Dispose(false);
            this.Close();

        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            main1.updateCalled = false;
            DialogResult confirmDelete = MessageBox.Show("Are you sure that you want to delete this appointment?", "Confirm?", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                int AppointmentId = int.Parse(_singleAppointment[10].ToString());
                bool result = Controller.deleteAppointment(AppointmentId);
                if (result)
                {
                    main1.RefreshGrid();
                    MessageBox.Show("This appointment has been successfully deleted.");
                }
                else
                {
                    MessageBox.Show("This appointment has NOT been deleted.");
                }

                this.Dispose(false);
                this.Close();
            }


        }
    

        private void btnUpdateAppointmentExit_Click(object sender, EventArgs e)
        {
            main1.updateCalled = false;
            this.Close();
        }

        private void fillInAllFields()
        {
            //Customer Record
            txtCustomerId.Text = _singleCustomer.Tables[0].Rows[0]["customerId"].ToString();
            txtCustomerAddressId.Text = _singleCustomer.Tables[0].Rows[0]["addressId"].ToString();
            txtCustomerName.Text = _singleCustomer.Tables[0].Rows[0]["customerName"].ToString();
            txtCustomerActive.Text = _singleCustomer.Tables[0].Rows[0]["active"].ToString();
            txtCustomerCreateDate.Text = _singleCustomer.Tables[0].Rows[0]["createDate"].ToString();
            txtCustomerCreatedBy.Text = _singleCustomer.Tables[0].Rows[0]["createdBy"].ToString();
            txtCustomerLastUpdateDate.Text = _singleCustomer.Tables[0].Rows[0]["lastUpdate"].ToString();
            txtCustomerAddress.Text = _singleAddress.Tables[0].Rows[0]["address"].ToString();
            txtCustomerAddress2.Text = _singleAddress.Tables[0].Rows[0]["address2"].ToString();
            txtCustomerZIP.Text = _singleAddress.Tables[0].Rows[0]["postalCode"].ToString();
            txtCustomerCity.Text = _singleCity.Tables[0].Rows[0]["city"].ToString();
            txtCustomerCountry.Text = _singleCountry.Tables[0].Rows[0]["country"].ToString();

            //Appointment
            txtAppointmentTitle.Text = _singleAppointment[2].ToString();
            txtAppointmentType.Text = _singleAppointment[6].ToString();
            txtAppointmentDescription.Text = _singleAppointment[3].ToString();
            txtAppointmentLocation.Text = _singleAppointment[4].ToString();
            txtAppointmentURL.Text = _singleAppointment[7].ToString();
            txtAppointmentContact.Text = _singleAppointment[5].ToString();
            dtStart.Value = Convert.ToDateTime(_singleAppointment[8].ToString());
            dtEnd.Value = Convert.ToDateTime(_singleAppointment[9].ToString());
        }
    }
}
