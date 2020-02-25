namespace C969_BOP1_Potesta_David_001243829
{
    partial class AppointmentMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbCalendar = new System.Windows.Forms.GroupBox();
            this.lblCalendarNotice = new System.Windows.Forms.Label();
            this.radWeekly = new System.Windows.Forms.RadioButton();
            this.radMonthly = new System.Windows.Forms.RadioButton();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.lblMain = new System.Windows.Forms.Label();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.gbReports = new System.Windows.Forms.GroupBox();
            this.btnReportsLongAppt = new System.Windows.Forms.Button();
            this.btnReportSchedules = new System.Windows.Forms.Button();
            this.btnReportsApptCount = new System.Windows.Forms.Button();
            this.lblReports = new System.Windows.Forms.Label();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.gbReports.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCalendar
            // 
            this.gbCalendar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.gbCalendar.Controls.Add(this.lblCalendarNotice);
            this.gbCalendar.Controls.Add(this.radWeekly);
            this.gbCalendar.Controls.Add(this.radMonthly);
            this.gbCalendar.Controls.Add(this.btnAddAppointment);
            this.gbCalendar.Controls.Add(this.lblMain);
            this.gbCalendar.Controls.Add(this.dgvCalendar);
            this.gbCalendar.Location = new System.Drawing.Point(7, 15);
            this.gbCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.gbCalendar.Name = "gbCalendar";
            this.gbCalendar.Padding = new System.Windows.Forms.Padding(2);
            this.gbCalendar.Size = new System.Drawing.Size(1137, 420);
            this.gbCalendar.TabIndex = 0;
            this.gbCalendar.TabStop = false;
            // 
            // lblCalendarNotice
            // 
            this.lblCalendarNotice.AutoSize = true;
            this.lblCalendarNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendarNotice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCalendarNotice.Location = new System.Drawing.Point(457, 46);
            this.lblCalendarNotice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCalendarNotice.Name = "lblCalendarNotice";
            this.lblCalendarNotice.Size = new System.Drawing.Size(294, 16);
            this.lblCalendarNotice.TabIndex = 5;
            this.lblCalendarNotice.Text = "Showing appointments for the next 7 Days";
            // 
            // radWeekly
            // 
            this.radWeekly.AutoSize = true;
            this.radWeekly.Checked = true;
            this.radWeekly.Location = new System.Drawing.Point(499, 27);
            this.radWeekly.Margin = new System.Windows.Forms.Padding(2);
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Size = new System.Drawing.Size(61, 17);
            this.radWeekly.TabIndex = 2;
            this.radWeekly.TabStop = true;
            this.radWeekly.Text = "Weekly";
            this.radWeekly.UseVisualStyleBackColor = true;
            this.radWeekly.CheckedChanged += new System.EventHandler(this.radWeekly_CheckedChanged);
            // 
            // radMonthly
            // 
            this.radMonthly.AutoSize = true;
            this.radMonthly.Location = new System.Drawing.Point(621, 27);
            this.radMonthly.Margin = new System.Windows.Forms.Padding(2);
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Size = new System.Drawing.Size(62, 17);
            this.radMonthly.TabIndex = 3;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "Monthly";
            this.radMonthly.UseVisualStyleBackColor = true;
            this.radMonthly.CheckedChanged += new System.EventHandler(this.radMonthly_CheckedChanged);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(11, 371);
            this.btnAddAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(57, 31);
            this.btnAddAppointment.TabIndex = 4;
            this.btnAddAppointment.Text = "Add";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMain.Location = new System.Drawing.Point(0, 7);
            this.lblMain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(354, 37);
            this.lblMain.TabIndex = 1;
            this.lblMain.Text = "APPOINTMENTmaker";
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCalendar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.Location = new System.Drawing.Point(14, 74);
            this.dgvCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.RowHeadersWidth = 72;
            this.dgvCalendar.RowTemplate.Height = 31;
            this.dgvCalendar.Size = new System.Drawing.Size(1115, 280);
            this.dgvCalendar.TabIndex = 0;
            this.dgvCalendar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCalendar_CellContentClick);
            // 
            // gbReports
            // 
            this.gbReports.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gbReports.Controls.Add(this.btnReportsLongAppt);
            this.gbReports.Controls.Add(this.btnReportSchedules);
            this.gbReports.Controls.Add(this.btnReportsApptCount);
            this.gbReports.Controls.Add(this.lblReports);
            this.gbReports.Location = new System.Drawing.Point(225, 445);
            this.gbReports.Margin = new System.Windows.Forms.Padding(2);
            this.gbReports.Name = "gbReports";
            this.gbReports.Padding = new System.Windows.Forms.Padding(2);
            this.gbReports.Size = new System.Drawing.Size(308, 133);
            this.gbReports.TabIndex = 1;
            this.gbReports.TabStop = false;
            // 
            // btnReportsLongAppt
            // 
            this.btnReportsLongAppt.Location = new System.Drawing.Point(193, 53);
            this.btnReportsLongAppt.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportsLongAppt.Name = "btnReportsLongAppt";
            this.btnReportsLongAppt.Size = new System.Drawing.Size(84, 54);
            this.btnReportsLongAppt.TabIndex = 7;
            this.btnReportsLongAppt.Text = "Long Appointments";
            this.btnReportsLongAppt.UseVisualStyleBackColor = true;
            this.btnReportsLongAppt.Click += new System.EventHandler(this.btnReportsLongAppt_Click);
            // 
            // btnReportSchedules
            // 
            this.btnReportSchedules.Location = new System.Drawing.Point(102, 53);
            this.btnReportSchedules.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportSchedules.Name = "btnReportSchedules";
            this.btnReportSchedules.Size = new System.Drawing.Size(84, 54);
            this.btnReportSchedules.TabIndex = 6;
            this.btnReportSchedules.Text = "Consultant Schedules";
            this.btnReportSchedules.UseVisualStyleBackColor = true;
            this.btnReportSchedules.Click += new System.EventHandler(this.btnReportSchedules_Click);
            // 
            // btnReportsApptCount
            // 
            this.btnReportsApptCount.Location = new System.Drawing.Point(14, 53);
            this.btnReportsApptCount.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportsApptCount.Name = "btnReportsApptCount";
            this.btnReportsApptCount.Size = new System.Drawing.Size(84, 54);
            this.btnReportsApptCount.TabIndex = 5;
            this.btnReportsApptCount.Text = "appointment types by month";
            this.btnReportsApptCount.UseVisualStyleBackColor = true;
            this.btnReportsApptCount.Click += new System.EventHandler(this.btnReportsApptCount_Click);
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblReports.Location = new System.Drawing.Point(89, 0);
            this.lblReports.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(124, 37);
            this.lblReports.TabIndex = 0;
            this.lblReports.Text = "reports";
            // 
            // gbCustomer
            // 
            this.gbCustomer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gbCustomer.Controls.Add(this.btnDeleteCustomer);
            this.gbCustomer.Controls.Add(this.btnEditCustomer);
            this.gbCustomer.Controls.Add(this.btnAddCustomer);
            this.gbCustomer.Controls.Add(this.lblCustomers);
            this.gbCustomer.Location = new System.Drawing.Point(542, 445);
            this.gbCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Padding = new System.Windows.Forms.Padding(2);
            this.gbCustomer.Size = new System.Drawing.Size(299, 133);
            this.gbCustomer.TabIndex = 2;
            this.gbCustomer.TabStop = false;
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(200, 61);
            this.btnDeleteCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(57, 31);
            this.btnDeleteCustomer.TabIndex = 7;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(114, 61);
            this.btnEditCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(57, 31);
            this.btnEditCustomer.TabIndex = 6;
            this.btnEditCustomer.Text = "Edit";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(30, 61);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(57, 31);
            this.btnAddCustomer.TabIndex = 5;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCustomers.Location = new System.Drawing.Point(72, 0);
            this.lblCustomers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(174, 37);
            this.lblCustomers.TabIndex = 0;
            this.lblCustomers.Text = "customers";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(954, 506);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 31);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AppointmentMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 581);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gbCustomer);
            this.Controls.Add(this.gbReports);
            this.Controls.Add(this.gbCalendar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AppointmentMain";
            this.Text = "AppointmentMain";
            this.gbCalendar.ResumeLayout(false);
            this.gbCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.gbReports.ResumeLayout(false);
            this.gbReports.PerformLayout();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCalendar;
        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.RadioButton radMonthly;
        private System.Windows.Forms.RadioButton radWeekly;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.GroupBox gbReports;
        private System.Windows.Forms.Button btnReportsLongAppt;
        private System.Windows.Forms.Button btnReportSchedules;
        private System.Windows.Forms.Button btnReportsApptCount;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblCalendarNotice;
    }
}