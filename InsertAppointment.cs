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
    public partial class InsertAppointment : Form
    {
        private readonly AppointmentMain main1;
        public InsertAppointment(AppointmentMain main)
        {
            InitializeComponent();
            main1 = main;
            dtStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void btnInsertAppointmentExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsertAppointment_Click(object sender, EventArgs e)
        {
            if(!Controller.ValidateTextBoxes(this))
            {
                return;
            }
            if(!Controller.ValidateDateTime(dtStart,dtEnd))
            {
                return;
            }
            Appointment appointmentInfo = new Appointment();
            int customerId;
            int.TryParse(txtCustomerId.Text, out customerId);
            appointmentInfo.customerId = customerId;
            appointmentInfo.userId = Controller.retrieveUserId();
            appointmentInfo.title = txtAppointmentTitle.Text;
            appointmentInfo.description = txtAppointmentDescription.Text;
            appointmentInfo.location = txtAppointmentLocation.Text;
            appointmentInfo.contact = txtAppointmentContact.Text;
            appointmentInfo.type = txtAppointmentType.Text;
            appointmentInfo.url = txtAppointmentURL.Text;
            appointmentInfo.start = dtStart.Value;
            appointmentInfo.end = dtEnd.Value;
 

            DialogResult confirmInsert = MessageBox.Show("Are you sure that you want to add this appointment?", "Confirm?", MessageBoxButtons.YesNo);
            if (confirmInsert == DialogResult.Yes)
            {

                bool result = Controller.insertAppointment(appointmentInfo);
                if (result)
                {
                    main1.RefreshGrid();
                    MessageBox.Show($"Appointment with: {appointmentInfo.contact} has been successfully added.");

                }
                else
                {
                    MessageBox.Show($"ERROR: Appointment with:: {appointmentInfo.contact} has NOT been added.");
                }

                this.Dispose(false);
                this.Close();
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            int customerId = Controller.getCustomerId(txtCustomerSearch.Text);
            txtCustomerId.Text = customerId.ToString();
            if (customerId == 0)
            {
                MessageBox.Show("No Customer Found.  Please Try Your Search Again.");
                txtCustomerSearch.Text = "";
                txtCustomerId.Text = "";
            }
        }
    }
}
