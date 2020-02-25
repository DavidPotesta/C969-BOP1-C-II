using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_BOP1_Potesta_David_001243829
{
    public partial class AppointmentMain : Form
    {
        public bool updateCalled = false;
        private bool _addedMOREinfoColumn = false;
        public AppointmentMain()
        {
            InitializeComponent();
            dgvCalendar.AutoGenerateColumns = true;
            dgvCalendar.DataSource = queryCalendar(radWeekly.Checked ? true : false);
            dgvCalendar.DataMember = "Table";
            ConvertUTCtoLocalTime();
            GetReminders(dgvCalendar);
            lblCalendarNotice.Text = "Showing appointments for the next 7 Days";
        }

        public void RefreshGrid()
        {
            dgvCalendar.DataSource = queryCalendar(radWeekly.Checked ? true : false);
            ConvertUTCtoLocalTime();
        }

        private DataSet queryCalendar(bool viewChoice)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                string calendarViewChoice = "";
                if (viewChoice)
                {
                    calendarViewChoice = DateTime.UtcNow.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    calendarViewChoice = DateTime.UtcNow.AddDays(30).ToString("yyyy-MM-dd HH:mm:ss");
                }
                MySqlCommand cmd = new MySqlCommand($"SELECT customerId,title,description,location,contact,type,url,start,end,appointmentId FROM appointment WHERE userId = '{Controller.retrieveUserId()}' AND start < '{calendarViewChoice}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                //Make Dataset look nice:
                ds.Tables[0].Columns[0].ColumnName = "Customer ID";
                ds.Tables[0].Columns[1].ColumnName = "Title";
                ds.Tables[0].Columns[2].ColumnName = "Description";
                ds.Tables[0].Columns[3].ColumnName = "Location";
                ds.Tables[0].Columns[4].ColumnName = "Contact";
                ds.Tables[0].Columns[5].ColumnName = "Type";
                ds.Tables[0].Columns[6].ColumnName = "URL";
                ds.Tables[0].Columns[7].ColumnName = "Start";
                ds.Tables[0].Columns[8].ColumnName = "End";
                ds.Tables[0].Columns[9].ColumnName = "AppointmentId";

                if (!_addedMOREinfoColumn)
                {
                    // Add the UPDATE and DELETE functionality to the DataGridView
                    DataGridViewLinkColumn dgvlcUpdate = new DataGridViewLinkColumn();
                    dgvlcUpdate.UseColumnTextForLinkValue = true;
                    dgvlcUpdate.Text = "INFO";
                    dgvlcUpdate.Name = "More";
                    dgvCalendar.Columns.Insert(0, dgvlcUpdate);
                    dgvCalendar.CellContentClick += new DataGridViewCellEventHandler(dgvCalendar_CellContentClick);
                    _addedMOREinfoColumn = true;
                }
                return ds;
            }

        }

        private void GetReminders(DataGridView dgv)
        {
            string AppointmentAlert = $"YOU HAVE APPOINTMENTS SOON \n\n";
            bool ShowAlert = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {

                if (row.Cells["start"].Value != null)
                {
                    DateTime appointment = DateTime.Parse(row.Cells["start"].Value.ToString());
                    if (appointment.Subtract(DateTime.Now).TotalMinutes <= 15 && appointment.Subtract(DateTime.Now).TotalMinutes >= 0)
                    {

                        AppointmentAlert += $"{row.Cells["title"].Value.ToString()} is starting at {row.Cells["start"].Value.ToString()} with {row.Cells["contact"].Value.ToString()}\n";
                        ShowAlert = true;
                    }

                }
            }
            if(ShowAlert)
            {
                MessageBox.Show(AppointmentAlert);
            }
        }

        private void ConvertUTCtoLocalTime()
        {
            foreach (DataGridViewRow row in dgvCalendar.Rows)
            {
                if (row.Cells[8].Value == null || row.Cells[8].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells[8].Value.ToString()))
                {
                    // Do nothing if row is null
                }
                else
                {
                    DateTime start = DateTime.Parse(row.Cells[8].Value.ToString()).ToLocalTime();
                    row.Cells[8].Value = start.ToString();
                    DateTime end = DateTime.Parse(row.Cells[9].Value.ToString()).ToLocalTime();
                    row.Cells[9].Value = end.ToString();
                    if (row.Index == (dgvCalendar.Rows.Count - 2))
                        break;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Goodbye!");
            Application.Exit();
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            InsertCustomer insertCustomer = new InsertCustomer();
            insertCustomer.Show();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.Show();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            updateCustomer.Show();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            InsertAppointment insertAppointment = new InsertAppointment(this);
            insertAppointment.Show();
        }

        private void dgvCalendar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!updateCalled)
            {
            DataGridView dgv = sender as DataGridView;
                if (dgv.Columns[e.ColumnIndex].Name == "More")
                {

                    var result = from cell in dgvCalendar.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>()
                                 select cell.Value;
                    List<Object> SingleAppointment = result.ToList();

                    UpdateAppointment updateAppointment = new UpdateAppointment(SingleAppointment, this);
                    updateAppointment.Show();
                    updateCalled = true;
                }
                    
            }
        }

        private void radWeekly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
            lblCalendarNotice.Text = "Showing appointments for the next 7 Days";
        }

        private void radMonthly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
            lblCalendarNotice.Text = "Showing appointments for the next 30 Days";
        }

        private void btnReportsApptCount_Click(object sender, EventArgs e)
        {
            ReportAppointmentType showAppointmentTypeReport = new ReportAppointmentType();
            showAppointmentTypeReport.Show();
        }

        private void btnReportSchedules_Click(object sender, EventArgs e)
        {
            ReportConsultantSchedule showConsultantScheduleReport = new ReportConsultantSchedule();
            showConsultantScheduleReport.Show();
        }

        private void btnReportsLongAppt_Click(object sender, EventArgs e)
        {
            ReportLongAppointments showLongAppointmentReport = new ReportLongAppointments();
            showLongAppointmentReport.Show();
        }
    }
}
