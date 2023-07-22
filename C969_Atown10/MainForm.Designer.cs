namespace C969_Atown10
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageCustomers = new System.Windows.Forms.TabPage();
            this.tabPageAppointments = new System.Windows.Forms.TabPage();
            this.tabPageCalendarView = new System.Windows.Forms.TabPage();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.labelCustomerList = new System.Windows.Forms.Label();
            this.listViewCustomers = new System.Windows.Forms.ListView();
            this.groupBoxCustomerDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxCustomerActions = new System.Windows.Forms.GroupBox();
            this.buttonAddCustomer = new System.Windows.Forms.Button();
            this.buttonUpdateCustomer = new System.Windows.Forms.Button();
            this.buttonDeleteCustomer = new System.Windows.Forms.Button();
            this.labelNameCustomer = new System.Windows.Forms.Label();
            this.textBoxNameCustomer = new System.Windows.Forms.TextBox();
            this.textBoxAddressIdCustomer = new System.Windows.Forms.TextBox();
            this.labelAddressIdCustomer = new System.Windows.Forms.Label();
            this.labelActiveCustomer = new System.Windows.Forms.Label();
            this.checkBoxActiveCustomer = new System.Windows.Forms.CheckBox();
            this.listViewAppointments = new System.Windows.Forms.ListView();
            this.labelAppointmentList = new System.Windows.Forms.Label();
            this.groupBoxAppointmentDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxAppointmentActions = new System.Windows.Forms.GroupBox();
            this.buttonAddAppointment = new System.Windows.Forms.Button();
            this.buttonUpdateAppointment = new System.Windows.Forms.Button();
            this.buttonDeleteAppointment = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelUserIdAppointment = new System.Windows.Forms.Label();
            this.textBoxCustomerIdAppointment = new System.Windows.Forms.TextBox();
            this.labelCustomerIdAppointment = new System.Windows.Forms.Label();
            this.textBoxDescriptionAppointment = new System.Windows.Forms.TextBox();
            this.labelDescriptionAppointment = new System.Windows.Forms.Label();
            this.textBoxTitleAppointment = new System.Windows.Forms.TextBox();
            this.labelTitleAppointment = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelLocationAppointment = new System.Windows.Forms.Label();
            this.labelEndAppointment = new System.Windows.Forms.Label();
            this.labelStartAppointment = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.labelUrlAppointment = new System.Windows.Forms.Label();
            this.textBoxTypeAppointment = new System.Windows.Forms.TextBox();
            this.labelTypeAppointment = new System.Windows.Forms.Label();
            this.textBoxContactAppointment = new System.Windows.Forms.TextBox();
            this.labelContactAppointment = new System.Windows.Forms.Label();
            this.dateTimePickerStartAppointment = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndAppointment = new System.Windows.Forms.DateTimePicker();
            this.labelCalendarView = new System.Windows.Forms.Label();
            this.groupBoxViewSelection = new System.Windows.Forms.GroupBox();
            this.radioButtonMothView = new System.Windows.Forms.RadioButton();
            this.radioButtonWeekView = new System.Windows.Forms.RadioButton();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.listViewAppointmentsCalendar = new System.Windows.Forms.ListView();
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.labelReports = new System.Windows.Forms.Label();
            this.comboBoxReportSelection = new System.Windows.Forms.ComboBox();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageCustomers.SuspendLayout();
            this.tabPageAppointments.SuspendLayout();
            this.tabPageCalendarView.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.groupBoxCustomerDetails.SuspendLayout();
            this.groupBoxCustomerActions.SuspendLayout();
            this.groupBoxAppointmentDetails.SuspendLayout();
            this.groupBoxAppointmentActions.SuspendLayout();
            this.groupBoxViewSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment Scheduler";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(890, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 36);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(779, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 36);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageCustomers);
            this.tabControlMain.Controls.Add(this.tabPageAppointments);
            this.tabControlMain.Controls.Add(this.tabPageCalendarView);
            this.tabControlMain.Controls.Add(this.tabPageReports);
            this.tabControlMain.Location = new System.Drawing.Point(17, 54);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1130, 859);
            this.tabControlMain.TabIndex = 3;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageCustomers
            // 
            this.tabPageCustomers.Controls.Add(this.groupBoxCustomerActions);
            this.tabPageCustomers.Controls.Add(this.groupBoxCustomerDetails);
            this.tabPageCustomers.Controls.Add(this.listViewCustomers);
            this.tabPageCustomers.Controls.Add(this.labelCustomerList);
            this.tabPageCustomers.Location = new System.Drawing.Point(4, 25);
            this.tabPageCustomers.Name = "tabPageCustomers";
            this.tabPageCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustomers.Size = new System.Drawing.Size(1122, 830);
            this.tabPageCustomers.TabIndex = 0;
            this.tabPageCustomers.Text = "Customers";
            this.tabPageCustomers.UseVisualStyleBackColor = true;
            // 
            // tabPageAppointments
            // 
            this.tabPageAppointments.Controls.Add(this.groupBoxAppointmentActions);
            this.tabPageAppointments.Controls.Add(this.groupBoxAppointmentDetails);
            this.tabPageAppointments.Controls.Add(this.listViewAppointments);
            this.tabPageAppointments.Controls.Add(this.labelAppointmentList);
            this.tabPageAppointments.Location = new System.Drawing.Point(4, 25);
            this.tabPageAppointments.Name = "tabPageAppointments";
            this.tabPageAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAppointments.Size = new System.Drawing.Size(1122, 830);
            this.tabPageAppointments.TabIndex = 1;
            this.tabPageAppointments.Text = "Appointments";
            this.tabPageAppointments.UseVisualStyleBackColor = true;
            // 
            // tabPageCalendarView
            // 
            this.tabPageCalendarView.Controls.Add(this.listViewAppointmentsCalendar);
            this.tabPageCalendarView.Controls.Add(this.monthCalendar);
            this.tabPageCalendarView.Controls.Add(this.groupBoxViewSelection);
            this.tabPageCalendarView.Controls.Add(this.labelCalendarView);
            this.tabPageCalendarView.Location = new System.Drawing.Point(4, 25);
            this.tabPageCalendarView.Name = "tabPageCalendarView";
            this.tabPageCalendarView.Size = new System.Drawing.Size(1122, 830);
            this.tabPageCalendarView.TabIndex = 2;
            this.tabPageCalendarView.Text = "Calendar";
            this.tabPageCalendarView.UseVisualStyleBackColor = true;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.buttonGenerateReport);
            this.tabPageReports.Controls.Add(this.comboBoxReportSelection);
            this.tabPageReports.Controls.Add(this.labelReports);
            this.tabPageReports.Controls.Add(this.dataGridViewReport);
            this.tabPageReports.Location = new System.Drawing.Point(4, 25);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(1122, 830);
            this.tabPageReports.TabIndex = 3;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // labelCustomerList
            // 
            this.labelCustomerList.AutoSize = true;
            this.labelCustomerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerList.Location = new System.Drawing.Point(6, 3);
            this.labelCustomerList.Name = "labelCustomerList";
            this.labelCustomerList.Size = new System.Drawing.Size(128, 20);
            this.labelCustomerList.TabIndex = 0;
            this.labelCustomerList.Text = "Customer List";
            // 
            // listViewCustomers
            // 
            this.listViewCustomers.HideSelection = false;
            this.listViewCustomers.Location = new System.Drawing.Point(3, 35);
            this.listViewCustomers.Name = "listViewCustomers";
            this.listViewCustomers.Size = new System.Drawing.Size(1113, 544);
            this.listViewCustomers.TabIndex = 1;
            this.listViewCustomers.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxCustomerDetails
            // 
            this.groupBoxCustomerDetails.Controls.Add(this.checkBoxActiveCustomer);
            this.groupBoxCustomerDetails.Controls.Add(this.labelActiveCustomer);
            this.groupBoxCustomerDetails.Controls.Add(this.textBoxAddressIdCustomer);
            this.groupBoxCustomerDetails.Controls.Add(this.labelAddressIdCustomer);
            this.groupBoxCustomerDetails.Controls.Add(this.textBoxNameCustomer);
            this.groupBoxCustomerDetails.Controls.Add(this.labelNameCustomer);
            this.groupBoxCustomerDetails.Location = new System.Drawing.Point(10, 606);
            this.groupBoxCustomerDetails.Name = "groupBoxCustomerDetails";
            this.groupBoxCustomerDetails.Size = new System.Drawing.Size(668, 218);
            this.groupBoxCustomerDetails.TabIndex = 2;
            this.groupBoxCustomerDetails.TabStop = false;
            this.groupBoxCustomerDetails.Text = "Customer Details";
            // 
            // groupBoxCustomerActions
            // 
            this.groupBoxCustomerActions.Controls.Add(this.buttonDeleteCustomer);
            this.groupBoxCustomerActions.Controls.Add(this.buttonUpdateCustomer);
            this.groupBoxCustomerActions.Controls.Add(this.buttonAddCustomer);
            this.groupBoxCustomerActions.Location = new System.Drawing.Point(724, 606);
            this.groupBoxCustomerActions.Name = "groupBoxCustomerActions";
            this.groupBoxCustomerActions.Size = new System.Drawing.Size(392, 218);
            this.groupBoxCustomerActions.TabIndex = 3;
            this.groupBoxCustomerActions.TabStop = false;
            this.groupBoxCustomerActions.Text = "Actions";
            // 
            // buttonAddCustomer
            // 
            this.buttonAddCustomer.Location = new System.Drawing.Point(19, 85);
            this.buttonAddCustomer.Name = "buttonAddCustomer";
            this.buttonAddCustomer.Size = new System.Drawing.Size(75, 39);
            this.buttonAddCustomer.TabIndex = 0;
            this.buttonAddCustomer.Text = "Add";
            this.buttonAddCustomer.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateCustomer
            // 
            this.buttonUpdateCustomer.Location = new System.Drawing.Point(123, 85);
            this.buttonUpdateCustomer.Name = "buttonUpdateCustomer";
            this.buttonUpdateCustomer.Size = new System.Drawing.Size(75, 39);
            this.buttonUpdateCustomer.TabIndex = 1;
            this.buttonUpdateCustomer.Text = "Update";
            this.buttonUpdateCustomer.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteCustomer
            // 
            this.buttonDeleteCustomer.Location = new System.Drawing.Point(226, 85);
            this.buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            this.buttonDeleteCustomer.Size = new System.Drawing.Size(75, 39);
            this.buttonDeleteCustomer.TabIndex = 2;
            this.buttonDeleteCustomer.Text = "Delete";
            this.buttonDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // labelNameCustomer
            // 
            this.labelNameCustomer.AutoSize = true;
            this.labelNameCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameCustomer.Location = new System.Drawing.Point(128, 37);
            this.labelNameCustomer.Name = "labelNameCustomer";
            this.labelNameCustomer.Size = new System.Drawing.Size(62, 22);
            this.labelNameCustomer.TabIndex = 0;
            this.labelNameCustomer.Text = "Name:";
            // 
            // textBoxNameCustomer
            // 
            this.textBoxNameCustomer.Location = new System.Drawing.Point(199, 37);
            this.textBoxNameCustomer.Name = "textBoxNameCustomer";
            this.textBoxNameCustomer.Size = new System.Drawing.Size(343, 22);
            this.textBoxNameCustomer.TabIndex = 1;
            // 
            // textBoxAddressIdCustomer
            // 
            this.textBoxAddressIdCustomer.Location = new System.Drawing.Point(199, 85);
            this.textBoxAddressIdCustomer.Name = "textBoxAddressIdCustomer";
            this.textBoxAddressIdCustomer.Size = new System.Drawing.Size(343, 22);
            this.textBoxAddressIdCustomer.TabIndex = 3;
            // 
            // labelAddressIdCustomer
            // 
            this.labelAddressIdCustomer.AutoSize = true;
            this.labelAddressIdCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddressIdCustomer.Location = new System.Drawing.Point(90, 83);
            this.labelAddressIdCustomer.Name = "labelAddressIdCustomer";
            this.labelAddressIdCustomer.Size = new System.Drawing.Size(100, 22);
            this.labelAddressIdCustomer.TabIndex = 2;
            this.labelAddressIdCustomer.Text = "Address Id:";
            // 
            // labelActiveCustomer
            // 
            this.labelActiveCustomer.AutoSize = true;
            this.labelActiveCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActiveCustomer.Location = new System.Drawing.Point(126, 129);
            this.labelActiveCustomer.Name = "labelActiveCustomer";
            this.labelActiveCustomer.Size = new System.Drawing.Size(64, 22);
            this.labelActiveCustomer.TabIndex = 4;
            this.labelActiveCustomer.Text = "Active:";
            // 
            // checkBoxActiveCustomer
            // 
            this.checkBoxActiveCustomer.AutoSize = true;
            this.checkBoxActiveCustomer.Location = new System.Drawing.Point(199, 131);
            this.checkBoxActiveCustomer.Name = "checkBoxActiveCustomer";
            this.checkBoxActiveCustomer.Size = new System.Drawing.Size(18, 17);
            this.checkBoxActiveCustomer.TabIndex = 5;
            this.checkBoxActiveCustomer.UseVisualStyleBackColor = true;
            // 
            // listViewAppointments
            // 
            this.listViewAppointments.HideSelection = false;
            this.listViewAppointments.Location = new System.Drawing.Point(3, 35);
            this.listViewAppointments.Name = "listViewAppointments";
            this.listViewAppointments.Size = new System.Drawing.Size(1113, 544);
            this.listViewAppointments.TabIndex = 3;
            this.listViewAppointments.UseCompatibleStateImageBehavior = false;
            // 
            // labelAppointmentList
            // 
            this.labelAppointmentList.AutoSize = true;
            this.labelAppointmentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppointmentList.Location = new System.Drawing.Point(6, 3);
            this.labelAppointmentList.Name = "labelAppointmentList";
            this.labelAppointmentList.Size = new System.Drawing.Size(151, 20);
            this.labelAppointmentList.TabIndex = 2;
            this.labelAppointmentList.Text = "Appointment List";
            this.labelAppointmentList.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBoxAppointmentDetails
            // 
            this.groupBoxAppointmentDetails.Controls.Add(this.dateTimePickerEndAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.dateTimePickerStartAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelEndAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelStartAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBox5);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelUrlAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBoxTypeAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelTypeAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBoxContactAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelContactAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBox2);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelLocationAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBoxDescriptionAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelDescriptionAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBoxTitleAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelTitleAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBox1);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelUserIdAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.textBoxCustomerIdAppointment);
            this.groupBoxAppointmentDetails.Controls.Add(this.labelCustomerIdAppointment);
            this.groupBoxAppointmentDetails.Location = new System.Drawing.Point(10, 598);
            this.groupBoxAppointmentDetails.Name = "groupBoxAppointmentDetails";
            this.groupBoxAppointmentDetails.Size = new System.Drawing.Size(767, 226);
            this.groupBoxAppointmentDetails.TabIndex = 4;
            this.groupBoxAppointmentDetails.TabStop = false;
            this.groupBoxAppointmentDetails.Text = "Appointment Details";
            // 
            // groupBoxAppointmentActions
            // 
            this.groupBoxAppointmentActions.Controls.Add(this.buttonDeleteAppointment);
            this.groupBoxAppointmentActions.Controls.Add(this.buttonUpdateAppointment);
            this.groupBoxAppointmentActions.Controls.Add(this.buttonAddAppointment);
            this.groupBoxAppointmentActions.Location = new System.Drawing.Point(799, 598);
            this.groupBoxAppointmentActions.Name = "groupBoxAppointmentActions";
            this.groupBoxAppointmentActions.Size = new System.Drawing.Size(317, 226);
            this.groupBoxAppointmentActions.TabIndex = 5;
            this.groupBoxAppointmentActions.TabStop = false;
            this.groupBoxAppointmentActions.Text = "Actions";
            // 
            // buttonAddAppointment
            // 
            this.buttonAddAppointment.Location = new System.Drawing.Point(25, 86);
            this.buttonAddAppointment.Name = "buttonAddAppointment";
            this.buttonAddAppointment.Size = new System.Drawing.Size(75, 35);
            this.buttonAddAppointment.TabIndex = 0;
            this.buttonAddAppointment.Text = "Add";
            this.buttonAddAppointment.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateAppointment
            // 
            this.buttonUpdateAppointment.Location = new System.Drawing.Point(118, 86);
            this.buttonUpdateAppointment.Name = "buttonUpdateAppointment";
            this.buttonUpdateAppointment.Size = new System.Drawing.Size(75, 35);
            this.buttonUpdateAppointment.TabIndex = 1;
            this.buttonUpdateAppointment.Text = "Update";
            this.buttonUpdateAppointment.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteAppointment
            // 
            this.buttonDeleteAppointment.Location = new System.Drawing.Point(208, 86);
            this.buttonDeleteAppointment.Name = "buttonDeleteAppointment";
            this.buttonDeleteAppointment.Size = new System.Drawing.Size(75, 35);
            this.buttonDeleteAppointment.TabIndex = 2;
            this.buttonDeleteAppointment.Text = "Delete";
            this.buttonDeleteAppointment.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 22);
            this.textBox1.TabIndex = 7;
            // 
            // labelUserIdAppointment
            // 
            this.labelUserIdAppointment.AutoSize = true;
            this.labelUserIdAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserIdAppointment.Location = new System.Drawing.Point(72, 58);
            this.labelUserIdAppointment.Name = "labelUserIdAppointment";
            this.labelUserIdAppointment.Size = new System.Drawing.Size(75, 22);
            this.labelUserIdAppointment.TabIndex = 6;
            this.labelUserIdAppointment.Text = "User ID:";
            // 
            // textBoxCustomerIdAppointment
            // 
            this.textBoxCustomerIdAppointment.Location = new System.Drawing.Point(153, 21);
            this.textBoxCustomerIdAppointment.Name = "textBoxCustomerIdAppointment";
            this.textBoxCustomerIdAppointment.Size = new System.Drawing.Size(228, 22);
            this.textBoxCustomerIdAppointment.TabIndex = 5;
            // 
            // labelCustomerIdAppointment
            // 
            this.labelCustomerIdAppointment.AutoSize = true;
            this.labelCustomerIdAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerIdAppointment.Location = new System.Drawing.Point(36, 21);
            this.labelCustomerIdAppointment.Name = "labelCustomerIdAppointment";
            this.labelCustomerIdAppointment.Size = new System.Drawing.Size(114, 22);
            this.labelCustomerIdAppointment.TabIndex = 4;
            this.labelCustomerIdAppointment.Text = "Customer ID:";
            // 
            // textBoxDescriptionAppointment
            // 
            this.textBoxDescriptionAppointment.Location = new System.Drawing.Point(153, 134);
            this.textBoxDescriptionAppointment.Name = "textBoxDescriptionAppointment";
            this.textBoxDescriptionAppointment.Size = new System.Drawing.Size(228, 22);
            this.textBoxDescriptionAppointment.TabIndex = 11;
            // 
            // labelDescriptionAppointment
            // 
            this.labelDescriptionAppointment.AutoSize = true;
            this.labelDescriptionAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescriptionAppointment.Location = new System.Drawing.Point(45, 134);
            this.labelDescriptionAppointment.Name = "labelDescriptionAppointment";
            this.labelDescriptionAppointment.Size = new System.Drawing.Size(105, 22);
            this.labelDescriptionAppointment.TabIndex = 10;
            this.labelDescriptionAppointment.Text = "Description:";
            // 
            // textBoxTitleAppointment
            // 
            this.textBoxTitleAppointment.Location = new System.Drawing.Point(153, 97);
            this.textBoxTitleAppointment.Name = "textBoxTitleAppointment";
            this.textBoxTitleAppointment.Size = new System.Drawing.Size(228, 22);
            this.textBoxTitleAppointment.TabIndex = 9;
            // 
            // labelTitleAppointment
            // 
            this.labelTitleAppointment.AutoSize = true;
            this.labelTitleAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleAppointment.Location = new System.Drawing.Point(97, 97);
            this.labelTitleAppointment.Name = "labelTitleAppointment";
            this.labelTitleAppointment.Size = new System.Drawing.Size(50, 22);
            this.labelTitleAppointment.TabIndex = 8;
            this.labelTitleAppointment.Text = "Title:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 172);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(228, 22);
            this.textBox2.TabIndex = 13;
            // 
            // labelLocationAppointment
            // 
            this.labelLocationAppointment.AutoSize = true;
            this.labelLocationAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocationAppointment.Location = new System.Drawing.Point(64, 172);
            this.labelLocationAppointment.Name = "labelLocationAppointment";
            this.labelLocationAppointment.Size = new System.Drawing.Size(83, 22);
            this.labelLocationAppointment.TabIndex = 12;
            this.labelLocationAppointment.Text = "Location:";
            // 
            // labelEndAppointment
            // 
            this.labelEndAppointment.AutoSize = true;
            this.labelEndAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndAppointment.Location = new System.Drawing.Point(468, 174);
            this.labelEndAppointment.Name = "labelEndAppointment";
            this.labelEndAppointment.Size = new System.Drawing.Size(47, 22);
            this.labelEndAppointment.TabIndex = 22;
            this.labelEndAppointment.Text = "End:";
            // 
            // labelStartAppointment
            // 
            this.labelStartAppointment.AutoSize = true;
            this.labelStartAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartAppointment.Location = new System.Drawing.Point(462, 136);
            this.labelStartAppointment.Name = "labelStartAppointment";
            this.labelStartAppointment.Size = new System.Drawing.Size(53, 22);
            this.labelStartAppointment.TabIndex = 20;
            this.labelStartAppointment.Text = "Start:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(521, 99);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(228, 22);
            this.textBox5.TabIndex = 19;
            // 
            // labelUrlAppointment
            // 
            this.labelUrlAppointment.AutoSize = true;
            this.labelUrlAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUrlAppointment.Location = new System.Drawing.Point(464, 99);
            this.labelUrlAppointment.Name = "labelUrlAppointment";
            this.labelUrlAppointment.Size = new System.Drawing.Size(51, 22);
            this.labelUrlAppointment.TabIndex = 18;
            this.labelUrlAppointment.Text = "URL:";
            // 
            // textBoxTypeAppointment
            // 
            this.textBoxTypeAppointment.Location = new System.Drawing.Point(521, 60);
            this.textBoxTypeAppointment.Name = "textBoxTypeAppointment";
            this.textBoxTypeAppointment.Size = new System.Drawing.Size(228, 22);
            this.textBoxTypeAppointment.TabIndex = 17;
            // 
            // labelTypeAppointment
            // 
            this.labelTypeAppointment.AutoSize = true;
            this.labelTypeAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTypeAppointment.Location = new System.Drawing.Point(459, 60);
            this.labelTypeAppointment.Name = "labelTypeAppointment";
            this.labelTypeAppointment.Size = new System.Drawing.Size(56, 22);
            this.labelTypeAppointment.TabIndex = 16;
            this.labelTypeAppointment.Text = "Type:";
            // 
            // textBoxContactAppointment
            // 
            this.textBoxContactAppointment.Location = new System.Drawing.Point(521, 23);
            this.textBoxContactAppointment.Name = "textBoxContactAppointment";
            this.textBoxContactAppointment.Size = new System.Drawing.Size(228, 22);
            this.textBoxContactAppointment.TabIndex = 15;
            // 
            // labelContactAppointment
            // 
            this.labelContactAppointment.AutoSize = true;
            this.labelContactAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContactAppointment.Location = new System.Drawing.Point(438, 23);
            this.labelContactAppointment.Name = "labelContactAppointment";
            this.labelContactAppointment.Size = new System.Drawing.Size(77, 22);
            this.labelContactAppointment.TabIndex = 14;
            this.labelContactAppointment.Text = "Contact:";
            // 
            // dateTimePickerStartAppointment
            // 
            this.dateTimePickerStartAppointment.Location = new System.Drawing.Point(521, 136);
            this.dateTimePickerStartAppointment.Name = "dateTimePickerStartAppointment";
            this.dateTimePickerStartAppointment.Size = new System.Drawing.Size(228, 22);
            this.dateTimePickerStartAppointment.TabIndex = 23;
            // 
            // dateTimePickerEndAppointment
            // 
            this.dateTimePickerEndAppointment.Location = new System.Drawing.Point(521, 174);
            this.dateTimePickerEndAppointment.Name = "dateTimePickerEndAppointment";
            this.dateTimePickerEndAppointment.Size = new System.Drawing.Size(228, 22);
            this.dateTimePickerEndAppointment.TabIndex = 24;
            // 
            // labelCalendarView
            // 
            this.labelCalendarView.AutoSize = true;
            this.labelCalendarView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCalendarView.Location = new System.Drawing.Point(3, 0);
            this.labelCalendarView.Name = "labelCalendarView";
            this.labelCalendarView.Size = new System.Drawing.Size(130, 20);
            this.labelCalendarView.TabIndex = 3;
            this.labelCalendarView.Text = "Calendar View";
            this.labelCalendarView.Click += new System.EventHandler(this.labelCalendarView_Click);
            // 
            // groupBoxViewSelection
            // 
            this.groupBoxViewSelection.Controls.Add(this.radioButtonWeekView);
            this.groupBoxViewSelection.Controls.Add(this.radioButtonMothView);
            this.groupBoxViewSelection.Location = new System.Drawing.Point(376, 3);
            this.groupBoxViewSelection.Name = "groupBoxViewSelection";
            this.groupBoxViewSelection.Size = new System.Drawing.Size(393, 39);
            this.groupBoxViewSelection.TabIndex = 4;
            this.groupBoxViewSelection.TabStop = false;
            this.groupBoxViewSelection.Text = "View Selection";
            // 
            // radioButtonMothView
            // 
            this.radioButtonMothView.AutoSize = true;
            this.radioButtonMothView.Location = new System.Drawing.Point(76, 13);
            this.radioButtonMothView.Name = "radioButtonMothView";
            this.radioButtonMothView.Size = new System.Drawing.Size(96, 20);
            this.radioButtonMothView.TabIndex = 0;
            this.radioButtonMothView.TabStop = true;
            this.radioButtonMothView.Text = "Month View";
            this.radioButtonMothView.UseVisualStyleBackColor = true;
            // 
            // radioButtonWeekView
            // 
            this.radioButtonWeekView.AutoSize = true;
            this.radioButtonWeekView.Location = new System.Drawing.Point(185, 13);
            this.radioButtonWeekView.Name = "radioButtonWeekView";
            this.radioButtonWeekView.Size = new System.Drawing.Size(96, 20);
            this.radioButtonWeekView.TabIndex = 1;
            this.radioButtonWeekView.TabStop = true;
            this.radioButtonWeekView.Text = "Week View";
            this.radioButtonWeekView.UseVisualStyleBackColor = true;
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.monthCalendar.Location = new System.Drawing.Point(160, 72);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 5;
            // 
            // listViewAppointmentsCalendar
            // 
            this.listViewAppointmentsCalendar.HideSelection = false;
            this.listViewAppointmentsCalendar.Location = new System.Drawing.Point(160, 316);
            this.listViewAppointmentsCalendar.Name = "listViewAppointmentsCalendar";
            this.listViewAppointmentsCalendar.Size = new System.Drawing.Size(794, 314);
            this.listViewAppointmentsCalendar.TabIndex = 6;
            this.listViewAppointmentsCalendar.UseCompatibleStateImageBehavior = false;
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReport.Location = new System.Drawing.Point(36, 96);
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.RowHeadersWidth = 51;
            this.dataGridViewReport.RowTemplate.Height = 24;
            this.dataGridViewReport.Size = new System.Drawing.Size(1056, 690);
            this.dataGridViewReport.TabIndex = 0;
            // 
            // labelReports
            // 
            this.labelReports.AutoSize = true;
            this.labelReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReports.Location = new System.Drawing.Point(3, 0);
            this.labelReports.Name = "labelReports";
            this.labelReports.Size = new System.Drawing.Size(75, 20);
            this.labelReports.TabIndex = 4;
            this.labelReports.Text = "Reports";
            // 
            // comboBoxReportSelection
            // 
            this.comboBoxReportSelection.FormattingEnabled = true;
            this.comboBoxReportSelection.Items.AddRange(new object[] {
            "Appointment Types by Month",
            "Consultant Schedules",
            "Customer Statistics"});
            this.comboBoxReportSelection.Location = new System.Drawing.Point(406, 40);
            this.comboBoxReportSelection.Name = "comboBoxReportSelection";
            this.comboBoxReportSelection.Size = new System.Drawing.Size(257, 24);
            this.comboBoxReportSelection.TabIndex = 5;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Location = new System.Drawing.Point(669, 40);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(83, 24);
            this.buttonGenerateReport.TabIndex = 6;
            this.buttonGenerateReport.Text = "Generate";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 925);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageCustomers.ResumeLayout(false);
            this.tabPageCustomers.PerformLayout();
            this.tabPageAppointments.ResumeLayout(false);
            this.tabPageAppointments.PerformLayout();
            this.tabPageCalendarView.ResumeLayout(false);
            this.tabPageCalendarView.PerformLayout();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageReports.PerformLayout();
            this.groupBoxCustomerDetails.ResumeLayout(false);
            this.groupBoxCustomerDetails.PerformLayout();
            this.groupBoxCustomerActions.ResumeLayout(false);
            this.groupBoxAppointmentDetails.ResumeLayout(false);
            this.groupBoxAppointmentDetails.PerformLayout();
            this.groupBoxAppointmentActions.ResumeLayout(false);
            this.groupBoxViewSelection.ResumeLayout(false);
            this.groupBoxViewSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCustomers;
        private System.Windows.Forms.TabPage tabPageAppointments;
        private System.Windows.Forms.TabPage tabPageCalendarView;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.GroupBox groupBoxCustomerDetails;
        private System.Windows.Forms.ListView listViewCustomers;
        private System.Windows.Forms.Label labelCustomerList;
        private System.Windows.Forms.GroupBox groupBoxCustomerActions;
        private System.Windows.Forms.Button buttonDeleteCustomer;
        private System.Windows.Forms.Button buttonUpdateCustomer;
        private System.Windows.Forms.Button buttonAddCustomer;
        private System.Windows.Forms.TextBox textBoxNameCustomer;
        private System.Windows.Forms.Label labelNameCustomer;
        private System.Windows.Forms.CheckBox checkBoxActiveCustomer;
        private System.Windows.Forms.Label labelActiveCustomer;
        private System.Windows.Forms.TextBox textBoxAddressIdCustomer;
        private System.Windows.Forms.Label labelAddressIdCustomer;
        private System.Windows.Forms.ListView listViewAppointments;
        private System.Windows.Forms.Label labelAppointmentList;
        private System.Windows.Forms.GroupBox groupBoxAppointmentDetails;
        private System.Windows.Forms.GroupBox groupBoxAppointmentActions;
        private System.Windows.Forms.Button buttonDeleteAppointment;
        private System.Windows.Forms.Button buttonUpdateAppointment;
        private System.Windows.Forms.Button buttonAddAppointment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelUserIdAppointment;
        private System.Windows.Forms.TextBox textBoxCustomerIdAppointment;
        private System.Windows.Forms.Label labelCustomerIdAppointment;
        private System.Windows.Forms.Label labelEndAppointment;
        private System.Windows.Forms.Label labelStartAppointment;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label labelUrlAppointment;
        private System.Windows.Forms.TextBox textBoxTypeAppointment;
        private System.Windows.Forms.Label labelTypeAppointment;
        private System.Windows.Forms.TextBox textBoxContactAppointment;
        private System.Windows.Forms.Label labelContactAppointment;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelLocationAppointment;
        private System.Windows.Forms.TextBox textBoxDescriptionAppointment;
        private System.Windows.Forms.Label labelDescriptionAppointment;
        private System.Windows.Forms.TextBox textBoxTitleAppointment;
        private System.Windows.Forms.Label labelTitleAppointment;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndAppointment;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartAppointment;
        private System.Windows.Forms.Label labelCalendarView;
        private System.Windows.Forms.GroupBox groupBoxViewSelection;
        private System.Windows.Forms.RadioButton radioButtonWeekView;
        private System.Windows.Forms.RadioButton radioButtonMothView;
        private System.Windows.Forms.ListView listViewAppointmentsCalendar;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.DataGridView dataGridViewReport;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.ComboBox comboBoxReportSelection;
        private System.Windows.Forms.Label labelReports;
    }
}