namespace WindowsFormsApp2
{
    partial class VaccinationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRecordId;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblVaccine;
        private System.Windows.Forms.Label lblDose;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblDoseCount;
        private System.Windows.Forms.Label lblDoseCountValue;
        private System.Windows.Forms.TextBox txtRecordId;
        private System.Windows.Forms.ComboBox comboPerson;
        private System.Windows.Forms.ComboBox comboStaff;
        private System.Windows.Forms.ComboBox comboVaccine;
        private System.Windows.Forms.TextBox txtDose;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox comboRoom;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnUpdateRecord;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnShowDoseCount;
        private System.Windows.Forms.TextBox txtSearchRecord;
        private System.Windows.Forms.Button btnSearchRecord;
        private System.Windows.Forms.DataGridView dgvVaccinationRecords;
        private System.Windows.Forms.BindingSource vaccinationBindingSource;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblRecordId = new System.Windows.Forms.Label();
            this.lblPerson = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblVaccine = new System.Windows.Forms.Label();
            this.lblDose = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblDoseCount = new System.Windows.Forms.Label();
            this.lblDoseCountValue = new System.Windows.Forms.Label();
            this.txtRecordId = new System.Windows.Forms.TextBox();
            this.comboPerson = new System.Windows.Forms.ComboBox();
            this.comboStaff = new System.Windows.Forms.ComboBox();
            this.comboVaccine = new System.Windows.Forms.ComboBox();
            this.txtDose = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.comboRoom = new System.Windows.Forms.ComboBox();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnUpdateRecord = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnShowDoseCount = new System.Windows.Forms.Button();
            this.txtSearchRecord = new System.Windows.Forms.TextBox();
            this.btnSearchRecord = new System.Windows.Forms.Button();
            this.dgvVaccinationRecords = new System.Windows.Forms.DataGridView();
            this.vaccinationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinationRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccinationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordId
            // 
            this.lblRecordId.AutoSize = true;
            this.lblRecordId.Location = new System.Drawing.Point(16, 18);
            this.lblRecordId.Name = "lblRecordId";
            this.lblRecordId.Size = new System.Drawing.Size(70, 17);
            this.lblRecordId.TabIndex = 0;
            this.lblRecordId.Text = "Record ID";
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Location = new System.Drawing.Point(16, 54);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(53, 17);
            this.lblPerson.TabIndex = 1;
            this.lblPerson.Text = "Person";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(16, 90);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(41, 17);
            this.lblStaff.TabIndex = 2;
            this.lblStaff.Text = "Staff";
            // 
            // lblVaccine
            // 
            this.lblVaccine.AutoSize = true;
            this.lblVaccine.Location = new System.Drawing.Point(16, 126);
            this.lblVaccine.Name = "lblVaccine";
            this.lblVaccine.Size = new System.Drawing.Size(63, 17);
            this.lblVaccine.TabIndex = 3;
            this.lblVaccine.Text = "Vaccine";
            // 
            // lblDose
            // 
            this.lblDose.AutoSize = true;
            this.lblDose.Location = new System.Drawing.Point(16, 162);
            this.lblDose.Name = "lblDose";
            this.lblDose.Size = new System.Drawing.Size(42, 17);
            this.lblDose.TabIndex = 4;
            this.lblDose.Text = "Dose";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(16, 198);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 17);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(16, 234);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(45, 17);
            this.lblRoom.TabIndex = 6;
            this.lblRoom.Text = "Room";
            // 
            // lblDoseCount
            // 
            this.lblDoseCount.AutoSize = true;
            this.lblDoseCount.Location = new System.Drawing.Point(380, 130);
            this.lblDoseCount.Name = "lblDoseCount";
            this.lblDoseCount.Size = new System.Drawing.Size(135, 17);
            this.lblDoseCount.TabIndex = 7;
            this.lblDoseCount.Text = "Patient Dose Count:";
            // 
            // lblDoseCountValue
            // 
            this.lblDoseCountValue.AutoSize = true;
            this.lblDoseCountValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDoseCountValue.Location = new System.Drawing.Point(521, 126);
            this.lblDoseCountValue.Name = "lblDoseCountValue";
            this.lblDoseCountValue.Size = new System.Drawing.Size(19, 23);
            this.lblDoseCountValue.TabIndex = 8;
            this.lblDoseCountValue.Text = "0";
            // 
            // txtRecordId
            // 
            this.txtRecordId.Location = new System.Drawing.Point(140, 15);
            this.txtRecordId.Name = "txtRecordId";
            this.txtRecordId.Size = new System.Drawing.Size(200, 22);
            this.txtRecordId.TabIndex = 9;
            // 
            // comboPerson
            // 
            this.comboPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPerson.FormattingEnabled = true;
            this.comboPerson.Location = new System.Drawing.Point(140, 51);
            this.comboPerson.Name = "comboPerson";
            this.comboPerson.Size = new System.Drawing.Size(200, 24);
            this.comboPerson.TabIndex = 10;
            // 
            // comboStaff
            // 
            this.comboStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStaff.FormattingEnabled = true;
            this.comboStaff.Location = new System.Drawing.Point(140, 87);
            this.comboStaff.Name = "comboStaff";
            this.comboStaff.Size = new System.Drawing.Size(200, 24);
            this.comboStaff.TabIndex = 11;
            // 
            // comboVaccine
            // 
            this.comboVaccine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVaccine.FormattingEnabled = true;
            this.comboVaccine.Location = new System.Drawing.Point(140, 123);
            this.comboVaccine.Name = "comboVaccine";
            this.comboVaccine.Size = new System.Drawing.Size(200, 24);
            this.comboVaccine.TabIndex = 12;
            // 
            // txtDose
            // 
            this.txtDose.Location = new System.Drawing.Point(140, 159);
            this.txtDose.Name = "txtDose";
            this.txtDose.Size = new System.Drawing.Size(200, 22);
            this.txtDose.TabIndex = 13;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(140, 195);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 14;
            // 
            // comboRoom
            // 
            this.comboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRoom.FormattingEnabled = true;
            this.comboRoom.Location = new System.Drawing.Point(140, 231);
            this.comboRoom.Name = "comboRoom";
            this.comboRoom.Size = new System.Drawing.Size(200, 24);
            this.comboRoom.TabIndex = 15;
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(380, 12);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(120, 30);
            this.btnAddRecord.TabIndex = 16;
            this.btnAddRecord.Text = "Add Record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // btnUpdateRecord
            // 
            this.btnUpdateRecord.Location = new System.Drawing.Point(380, 48);
            this.btnUpdateRecord.Name = "btnUpdateRecord";
            this.btnUpdateRecord.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateRecord.TabIndex = 17;
            this.btnUpdateRecord.Text = "Update";
            this.btnUpdateRecord.UseVisualStyleBackColor = true;
            this.btnUpdateRecord.Click += new System.EventHandler(this.btnUpdateRecord_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(380, 84);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteRecord.TabIndex = 18;
            this.btnDeleteRecord.Text = "Delete";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnShowDoseCount
            // 
            this.btnShowDoseCount.Location = new System.Drawing.Point(380, 126);
            this.btnShowDoseCount.Name = "btnShowDoseCount";
            this.btnShowDoseCount.Size = new System.Drawing.Size(120, 30);
            this.btnShowDoseCount.TabIndex = 19;
            this.btnShowDoseCount.Text = "Show Dose Count";
            this.btnShowDoseCount.UseVisualStyleBackColor = true;
            this.btnShowDoseCount.Click += new System.EventHandler(this.btnShowDoseCount_Click);
            // 
            // txtSearchRecord
            // 
            this.txtSearchRecord.Location = new System.Drawing.Point(140, 271);
            this.txtSearchRecord.Name = "txtSearchRecord";
            this.txtSearchRecord.Size = new System.Drawing.Size(200, 22);
            this.txtSearchRecord.TabIndex = 20;
            // 
            // btnSearchRecord
            // 
            this.btnSearchRecord.Location = new System.Drawing.Point(380, 266);
            this.btnSearchRecord.Name = "btnSearchRecord";
            this.btnSearchRecord.Size = new System.Drawing.Size(120, 30);
            this.btnSearchRecord.TabIndex = 21;
            this.btnSearchRecord.Text = "Search";
            this.btnSearchRecord.UseVisualStyleBackColor = true;
            this.btnSearchRecord.Click += new System.EventHandler(this.btnSearchRecord_Click);
            // 
            // dgvVaccinationRecords
            // 
            this.dgvVaccinationRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVaccinationRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccinationRecords.Location = new System.Drawing.Point(19, 310);
            this.dgvVaccinationRecords.MultiSelect = false;
            this.dgvVaccinationRecords.Name = "dgvVaccinationRecords";
            this.dgvVaccinationRecords.ReadOnly = true;
            this.dgvVaccinationRecords.RowTemplate.Height = 24;
            this.dgvVaccinationRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVaccinationRecords.Size = new System.Drawing.Size(760, 330);
            this.dgvVaccinationRecords.TabIndex = 22;
            this.dgvVaccinationRecords.SelectionChanged += new System.EventHandler(this.dgvVaccinationRecords_SelectionChanged);
            // 
            // VaccinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 660);
            this.Controls.Add(this.dgvVaccinationRecords);
            this.Controls.Add(this.btnSearchRecord);
            this.Controls.Add(this.txtSearchRecord);
            this.Controls.Add(this.btnShowDoseCount);
            this.Controls.Add(this.btnDeleteRecord);
            this.Controls.Add(this.btnUpdateRecord);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.comboRoom);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtDose);
            this.Controls.Add(this.comboVaccine);
            this.Controls.Add(this.comboStaff);
            this.Controls.Add(this.comboPerson);
            this.Controls.Add(this.txtRecordId);
            this.Controls.Add(this.lblDoseCountValue);
            this.Controls.Add(this.lblDoseCount);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDose);
            this.Controls.Add(this.lblVaccine);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblRecordId);
            this.Name = "VaccinationForm";
            this.Text = "Vaccination Records";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinationRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccinationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
