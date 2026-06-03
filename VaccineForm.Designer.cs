namespace WindowsFormsApp2
{
    partial class VaccineForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblVaccineId;
        private System.Windows.Forms.Label lblVaccineName;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.TextBox txtVaccineId;
        private System.Windows.Forms.TextBox txtVaccineName;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Button btnAddVaccine;
        private System.Windows.Forms.Button btnUpdateVaccine;
        private System.Windows.Forms.Button btnDeleteVaccine;
        private System.Windows.Forms.TextBox txtSearchVaccine;
        private System.Windows.Forms.Button btnSearchVaccine;
        private System.Windows.Forms.DataGridView dgvVaccines;
        private System.Windows.Forms.BindingSource vaccineBindingSource;

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
            this.lblVaccineId = new System.Windows.Forms.Label();
            this.lblVaccineName = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtVaccineId = new System.Windows.Forms.TextBox();
            this.txtVaccineName = new System.Windows.Forms.TextBox();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddVaccine = new System.Windows.Forms.Button();
            this.btnUpdateVaccine = new System.Windows.Forms.Button();
            this.btnDeleteVaccine = new System.Windows.Forms.Button();
            this.txtSearchVaccine = new System.Windows.Forms.TextBox();
            this.btnSearchVaccine = new System.Windows.Forms.Button();
            this.dgvVaccines = new System.Windows.Forms.DataGridView();
            this.vaccineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVaccineId
            // 
            this.lblVaccineId.AutoSize = true;
            this.lblVaccineId.Location = new System.Drawing.Point(16, 18);
            this.lblVaccineId.Name = "lblVaccineId";
            this.lblVaccineId.Size = new System.Drawing.Size(74, 17);
            this.lblVaccineId.TabIndex = 0;
            this.lblVaccineId.Text = "Vaccine ID";
            // 
            // lblVaccineName
            // 
            this.lblVaccineName.AutoSize = true;
            this.lblVaccineName.Location = new System.Drawing.Point(16, 54);
            this.lblVaccineName.Name = "lblVaccineName";
            this.lblVaccineName.Size = new System.Drawing.Size(103, 17);
            this.lblVaccineName.TabIndex = 1;
            this.lblVaccineName.Text = "Vaccine Name";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(16, 90);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(84, 17);
            this.lblExpiryDate.TabIndex = 2;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // txtVaccineId
            // 
            this.txtVaccineId.Location = new System.Drawing.Point(140, 15);
            this.txtVaccineId.Name = "txtVaccineId";
            this.txtVaccineId.Size = new System.Drawing.Size(200, 22);
            this.txtVaccineId.TabIndex = 3;
            // 
            // txtVaccineName
            // 
            this.txtVaccineName.Location = new System.Drawing.Point(140, 51);
            this.txtVaccineName.Name = "txtVaccineName";
            this.txtVaccineName.Size = new System.Drawing.Size(200, 22);
            this.txtVaccineName.TabIndex = 4;
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(140, 87);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 22);
            this.dtpExpiryDate.TabIndex = 5;
            // 
            // btnAddVaccine
            // 
            this.btnAddVaccine.Location = new System.Drawing.Point(380, 12);
            this.btnAddVaccine.Name = "btnAddVaccine";
            this.btnAddVaccine.Size = new System.Drawing.Size(100, 30);
            this.btnAddVaccine.TabIndex = 6;
            this.btnAddVaccine.Text = "Add Vaccine";
            this.btnAddVaccine.UseVisualStyleBackColor = true;
            this.btnAddVaccine.Click += new System.EventHandler(this.btnAddVaccine_Click);
            // 
            // btnUpdateVaccine
            // 
            this.btnUpdateVaccine.Location = new System.Drawing.Point(380, 48);
            this.btnUpdateVaccine.Name = "btnUpdateVaccine";
            this.btnUpdateVaccine.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateVaccine.TabIndex = 7;
            this.btnUpdateVaccine.Text = "Update";
            this.btnUpdateVaccine.UseVisualStyleBackColor = true;
            this.btnUpdateVaccine.Click += new System.EventHandler(this.btnUpdateVaccine_Click);
            // 
            // btnDeleteVaccine
            // 
            this.btnDeleteVaccine.Location = new System.Drawing.Point(380, 84);
            this.btnDeleteVaccine.Name = "btnDeleteVaccine";
            this.btnDeleteVaccine.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteVaccine.TabIndex = 8;
            this.btnDeleteVaccine.Text = "Delete";
            this.btnDeleteVaccine.UseVisualStyleBackColor = true;
            this.btnDeleteVaccine.Click += new System.EventHandler(this.btnDeleteVaccine_Click);
            // 
            // txtSearchVaccine
            // 
            this.txtSearchVaccine.Location = new System.Drawing.Point(140, 130);
            this.txtSearchVaccine.Name = "txtSearchVaccine";
            this.txtSearchVaccine.Size = new System.Drawing.Size(200, 22);
            this.txtSearchVaccine.TabIndex = 9;
            // 
            // btnSearchVaccine
            // 
            this.btnSearchVaccine.Location = new System.Drawing.Point(380, 125);
            this.btnSearchVaccine.Name = "btnSearchVaccine";
            this.btnSearchVaccine.Size = new System.Drawing.Size(100, 30);
            this.btnSearchVaccine.TabIndex = 10;
            this.btnSearchVaccine.Text = "Search";
            this.btnSearchVaccine.UseVisualStyleBackColor = true;
            this.btnSearchVaccine.Click += new System.EventHandler(this.btnSearchVaccine_Click);
            // 
            // dgvVaccines
            // 
            this.dgvVaccines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVaccines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccines.Location = new System.Drawing.Point(19, 170);
            this.dgvVaccines.MultiSelect = false;
            this.dgvVaccines.Name = "dgvVaccines";
            this.dgvVaccines.ReadOnly = true;
            this.dgvVaccines.RowTemplate.Height = 24;
            this.dgvVaccines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVaccines.Size = new System.Drawing.Size(760, 370);
            this.dgvVaccines.TabIndex = 11;
            this.dgvVaccines.SelectionChanged += new System.EventHandler(this.dgvVaccines_SelectionChanged);
            // 
            // VaccineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.dgvVaccines);
            this.Controls.Add(this.btnSearchVaccine);
            this.Controls.Add(this.txtSearchVaccine);
            this.Controls.Add(this.btnDeleteVaccine);
            this.Controls.Add(this.btnUpdateVaccine);
            this.Controls.Add(this.btnAddVaccine);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.txtVaccineName);
            this.Controls.Add(this.txtVaccineId);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.lblVaccineName);
            this.Controls.Add(this.lblVaccineId);
            this.Name = "VaccineForm";
            this.Text = "Vaccine Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
