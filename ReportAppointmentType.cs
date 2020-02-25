using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_BOP1_Potesta_David_001243829
{
    public partial class ReportAppointmentType : Form
    {
        public ReportAppointmentType()
        {
            InitializeComponent();
            CreateReport();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void CreateReport()
        {
            DataSet results = Controller.ReportAppointmentTypeByMonth();
            if (results.Tables[0].Rows.Count > 0)
            {
                StringBuilder b = new StringBuilder();
                b.Append($"MONTH       TYPE         COUNT\r\n");
                foreach (DataRow r in results.Tables[0].Rows)
                {
                    string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(r[0].ToString()));
                    b.AppendFormat("{0,-10} | {1,-10} | {2,5}\r\n", month, r[1], r[2]);

                }
                result.Text = b.ToString();
            }
            else
            {
                result.Text = "No appointments of any type are scheduled within the next month.";
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(result.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
            this.Close();
        }
    }
}
