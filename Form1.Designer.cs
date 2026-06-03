namespace WindowsFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel ribbonPanel;
        private System.Windows.Forms.FlowLayoutPanel ribbonActionsPanel;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Button btnAboutUs;
        private System.Windows.Forms.Button btnReportGeneration;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPerson;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.TabPage tabVaccine;
        private System.Windows.Forms.TabPage tabRoom;
        private System.Windows.Forms.TabPage tabVaccination;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ribbonPanel = new System.Windows.Forms.Panel();
            this.ribbonActionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.btnAboutUs = new System.Windows.Forms.Button();
            this.btnReportGeneration = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPerson = new System.Windows.Forms.TabPage();
            this.tabStaff = new System.Windows.Forms.TabPage();
            this.tabVaccine = new System.Windows.Forms.TabPage();
            this.tabRoom = new System.Windows.Forms.TabPage();
            this.tabVaccination = new System.Windows.Forms.TabPage();
            this.mainPanel.SuspendLayout();
            this.ribbonPanel.SuspendLayout();
            this.SuspendLayout();

            // mainPanel
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(900, 600);
            this.mainPanel.TabIndex = 0;

            // ribbonPanel
            this.ribbonPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ribbonPanel.Controls.Add(this.ribbonActionsPanel);
            this.ribbonPanel.Controls.Add(this.lblDashboardTitle);
            this.ribbonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonPanel.Location = new System.Drawing.Point(0, 0);
            this.ribbonPanel.Name = "ribbonPanel";
            this.ribbonPanel.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.ribbonPanel.Size = new System.Drawing.Size(900, 56);
            this.ribbonPanel.TabIndex = 0;

            // ribbonActionsPanel
            this.ribbonActionsPanel.Controls.Add(this.btnReportGeneration);
            this.ribbonActionsPanel.Controls.Add(this.btnAboutUs);
            this.ribbonActionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ribbonActionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ribbonActionsPanel.Location = new System.Drawing.Point(584, 10);
            this.ribbonActionsPanel.Name = "ribbonActionsPanel";
            this.ribbonActionsPanel.Padding = new System.Windows.Forms.Padding(0);
            this.ribbonActionsPanel.Size = new System.Drawing.Size(300, 36);
            this.ribbonActionsPanel.TabIndex = 1;
            this.ribbonActionsPanel.WrapContents = false;

            // lblDashboardTitle
            this.lblDashboardTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblDashboardTitle.Location = new System.Drawing.Point(16, 10);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(278, 36);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "Vaccination Dashboard";
            this.lblDashboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnAboutUs
            this.btnAboutUs.Name = "btnAboutUs";
            this.btnAboutUs.Size = new System.Drawing.Size(96, 30);
            this.btnAboutUs.TabIndex = 0;
            this.btnAboutUs.Text = "About Us";
            this.btnAboutUs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(179, 179, 179);
            this.btnAboutUs.FlatAppearance.BorderSize = 1;
            this.btnAboutUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutUs.BackColor = System.Drawing.Color.White;
            this.btnAboutUs.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.btnAboutUs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnAboutUs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAboutUs.UseVisualStyleBackColor = false;

            // btnReportGeneration
            this.btnReportGeneration.Name = "btnReportGeneration";
            this.btnReportGeneration.Size = new System.Drawing.Size(142, 30);
            this.btnReportGeneration.TabIndex = 1;
            this.btnReportGeneration.Text = "Report Generation";
            this.btnReportGeneration.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnReportGeneration.FlatAppearance.BorderSize = 1;
            this.btnReportGeneration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportGeneration.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnReportGeneration.ForeColor = System.Drawing.Color.White;
            this.btnReportGeneration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnReportGeneration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportGeneration.UseVisualStyleBackColor = false;

            // tabControl
            this.tabControl.Controls.Add(this.tabPerson);
            this.tabControl.Controls.Add(this.tabStaff);
            this.tabControl.Controls.Add(this.tabVaccine);
            this.tabControl.Controls.Add(this.tabRoom);
            this.tabControl.Controls.Add(this.tabVaccination);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 56);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 544);
            this.tabControl.TabIndex = 1;

            // tabPerson
            this.tabPerson.Location = new System.Drawing.Point(4, 25);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerson.Size = new System.Drawing.Size(892, 571);
            this.tabPerson.TabIndex = 0;
            this.tabPerson.Text = "Person";
            this.tabPerson.UseVisualStyleBackColor = true;

            // tabStaff
            this.tabStaff.Location = new System.Drawing.Point(4, 25);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Padding = new System.Windows.Forms.Padding(3);
            this.tabStaff.Size = new System.Drawing.Size(892, 571);
            this.tabStaff.TabIndex = 1;
            this.tabStaff.Text = "Staff";
            this.tabStaff.UseVisualStyleBackColor = true;

            // tabVaccine
            this.tabVaccine.Location = new System.Drawing.Point(4, 25);
            this.tabVaccine.Name = "tabVaccine";
            this.tabVaccine.Padding = new System.Windows.Forms.Padding(3);
            this.tabVaccine.Size = new System.Drawing.Size(892, 571);
            this.tabVaccine.TabIndex = 2;
            this.tabVaccine.Text = "Vaccine";
            this.tabVaccine.UseVisualStyleBackColor = true;

            // tabRoom
            this.tabRoom.Location = new System.Drawing.Point(4, 25);
            this.tabRoom.Name = "tabRoom";
            this.tabRoom.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoom.Size = new System.Drawing.Size(892, 571);
            this.tabRoom.TabIndex = 3;
            this.tabRoom.Text = "Room";
            this.tabRoom.UseVisualStyleBackColor = true;

            // tabVaccination
            this.tabVaccination.Location = new System.Drawing.Point(4, 25);
            this.tabVaccination.Name = "tabVaccination";
            this.tabVaccination.Padding = new System.Windows.Forms.Padding(3);
            this.tabVaccination.Size = new System.Drawing.Size(892, 571);
            this.tabVaccination.TabIndex = 4;
            this.tabVaccination.Text = "Vaccination";
            this.tabVaccination.UseVisualStyleBackColor = true;

            // mainPanel
            this.mainPanel.Controls.Add(this.tabControl);
            this.mainPanel.Controls.Add(this.ribbonPanel);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "VaccineCare Dashboard";
            this.mainPanel.ResumeLayout(false);
            this.ribbonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            // Initialize tabs after form is created
            InitializeTabs(this.tabControl);
        }

        #endregion
    }
}
