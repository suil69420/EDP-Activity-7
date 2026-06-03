using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class ReportGenerationForm : Form
    {
        private readonly Panel mainPanel;
        private readonly Panel headerPanel;
        private readonly Label lblTitle;
        private readonly Label lblSubtitle;
        private readonly PictureBox logoBox;
        private readonly TabControl tabControl;
        private readonly TabPage tabPersonReport;
        private readonly TabPage tabVaccineReport;
        private readonly TabPage tabVaccinationReport;
        private readonly TabPage tabViews;

        private readonly DataGridView dgvPersonReport;
        private readonly DataGridView dgvVaccineReport;
        private readonly DataGridView dgvVaccinationReport;
        private readonly DataGridView dgvViews;

        private readonly Button btnExportPerson;
        private readonly Button btnExportVaccine;
        private readonly Button btnExportVaccination;
        private readonly Button btnRefreshView;

        private readonly ComboBox cboViews;

        private DataTable personReport;
        private DataTable vaccineReport;
        private DataTable vaccinationReport;
        private DataTable currentViewReport;

        public ReportGenerationForm()
        {
            UiTheme.ApplyForm(this);
            Text = "Report Generation";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(1100, 720);
            MinimumSize = new Size(980, 620);
            Icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.ico"));

            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(14, 0, 14, 14)
            };

            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 76,
                Padding = new Padding(18, 12, 18, 10)
            };

            logoBox = new PictureBox
            {
                Location = new Point(18, 16),
                Size = new Size(42, 42),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            var logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.ico");
            if (File.Exists(logoPath))
            {
                logoBox.Image = new Icon(logoPath).ToBitmap();
            }

            lblTitle = new Label
            {
                AutoSize = true,
                Location = new Point(72, 14),
                Text = "Report Generation"
            };

            lblSubtitle = new Label
            {
                AutoSize = true,
                Location = new Point(73, 40),
                Text = "Excel reports and database views"
            };

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
                Padding = new Point(14, 5)
            };

            tabPersonReport = new TabPage("Person Report");
            tabVaccineReport = new TabPage("Vaccine Inventory");
            tabVaccinationReport = new TabPage("Vaccination History");
            tabViews = new TabPage("Report Views");

            dgvPersonReport = BuildGrid();
            dgvVaccineReport = BuildGrid();
            dgvVaccinationReport = BuildGrid();
            dgvViews = BuildGrid();

            btnExportPerson = BuildActionButton("Export PersonReport.xlsx", BtnExportPerson_Click, true);
            btnExportVaccine = BuildActionButton("Export VaccineInventory.xlsx", BtnExportVaccine_Click, true);
            btnExportVaccination = BuildActionButton("Export VaccinationHistory.xlsx", BtnExportVaccination_Click, true);
            btnRefreshView = BuildActionButton("Load View", BtnRefreshView_Click, false);

            cboViews = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 220
            };

            cboViews.Items.Add(new ViewOption("Patient History", "view_patient_history"));
            cboViews.Items.Add(new ViewOption("Staff Activity", "view_staff_activity"));
            cboViews.Items.Add(new ViewOption("Vaccine Inventory", "view_vaccine_inventory"));
            cboViews.SelectedIndex = 0;
            cboViews.SelectedIndexChanged += (s, e) => LoadSelectedView();

            BuildReportTab(tabPersonReport, dgvPersonReport, btnExportPerson);
            BuildReportTab(tabVaccineReport, dgvVaccineReport, btnExportVaccine);
            BuildReportTab(tabVaccinationReport, dgvVaccinationReport, btnExportVaccination);
            BuildViewsTab();

            UiTheme.ApplySurface(this);
            UiTheme.ApplySurface(mainPanel);
            UiTheme.ApplySurface(headerPanel);
            UiTheme.ApplyLabel(lblTitle, true);
            UiTheme.ApplyLabel(lblSubtitle);
            lblSubtitle.ForeColor = Color.FromArgb(88, 96, 105);
            UiTheme.ApplySurface(tabControl);
            UiTheme.ApplySurface(tabPersonReport);
            UiTheme.ApplySurface(tabVaccineReport);
            UiTheme.ApplySurface(tabVaccinationReport);
            UiTheme.ApplySurface(tabViews);
            UiTheme.ApplyDataGrid(dgvPersonReport);
            UiTheme.ApplyDataGrid(dgvVaccineReport);
            UiTheme.ApplyDataGrid(dgvVaccinationReport);
            UiTheme.ApplyDataGrid(dgvViews);

            tabControl.TabPages.Add(tabPersonReport);
            tabControl.TabPages.Add(tabVaccineReport);
            tabControl.TabPages.Add(tabVaccinationReport);
            tabControl.TabPages.Add(tabViews);

            headerPanel.Controls.Add(logoBox);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            mainPanel.Controls.Add(tabControl);
            mainPanel.Controls.Add(headerPanel);
            Controls.Add(mainPanel);

            Load += ReportGenerationForm_Load;
        }

        private void ReportGenerationForm_Load(object sender, EventArgs e)
        {
            LoadReportData();
            LoadSelectedView();
        }

        private static DataGridView BuildGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                RowTemplate = { Height = 28 },
                ColumnHeadersHeight = 34
            };
        }

        private static Button BuildActionButton(string text, EventHandler clickHandler, bool primary)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = true,
                Padding = new Padding(12, 4, 12, 4),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            if (primary)
            {
                UiTheme.ApplyPrimaryButton(button);
            }
            else
            {
                UiTheme.ApplySecondaryButton(button);
            }

            button.Click += clickHandler;
            return button;
        }

        private void BuildReportTab(TabPage tab, DataGridView grid, Button exportButton)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 58,
                Padding = new Padding(12, 10, 12, 10)
            };
            UiTheme.ApplySurface(panel);

            var titleLabel = new Label
            {
                AutoSize = true,
                Location = new Point(12, 17),
                Text = tab.Text
            };
            UiTheme.ApplyLabel(titleLabel, true);

            exportButton.Dock = DockStyle.Right;
            exportButton.Margin = new Padding(0);

            panel.Controls.Add(titleLabel);
            panel.Controls.Add(exportButton);
            tab.Controls.Add(grid);
            tab.Controls.Add(panel);
        }

        private void BuildViewsTab()
        {
            var topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(12, 10, 12, 10)
            };
            UiTheme.ApplySurface(topPanel);

            var lblView = new Label
            {
                Text = "Select View",
                AutoSize = true,
                Location = new Point(12, 19)
            };
            UiTheme.ApplyLabel(lblView);

            cboViews.Location = new Point(96, 15);
            UiTheme.ApplyComboBox(cboViews);
            btnRefreshView.Dock = DockStyle.Right;

            topPanel.Controls.Add(lblView);
            topPanel.Controls.Add(cboViews);
            topPanel.Controls.Add(btnRefreshView);

            tabViews.Controls.Add(dgvViews);
            tabViews.Controls.Add(topPanel);
        }

        private void LoadReportData()
        {
            try
            {
                personReport = DBHelper.ExecuteQuery(
                    @"SELECT person_id AS `Person ID`,
                             first_name AS `First Name`,
                             last_name AS `Last Name`,
                             person_contact_num AS `Contact Number`
                      FROM person
                      ORDER BY person_id");
                dgvPersonReport.DataSource = personReport;

                vaccineReport = DBHelper.ExecuteQuery(
                    @"SELECT vaccine_id AS `Vaccine ID`,
                             vaccine_name AS `Vaccine Name`,
                             vaccine_expiry_date AS `Expiry Date`
                      FROM vaccine
                      ORDER BY vaccine_id");
                dgvVaccineReport.DataSource = vaccineReport;

                vaccinationReport = DBHelper.ExecuteQuery(
                    @"SELECT vr.record_id AS `Record ID`,
                             CONCAT(p.first_name, ' ', p.last_name) AS `Person`,
                             v.vaccine_name AS `Vaccine`,
                             vr.vaccination_dose AS `Dose`,
                             vr.vaccination_date AS `Date`,
                             CONCAT(s.first_name, ' ', s.last_name) AS `Staff`,
                             r.room_name AS `Room`
                      FROM vaccination_record vr
                      LEFT JOIN person p ON vr.person_id = p.person_id
                      LEFT JOIN vaccine v ON vr.vaccine_id = v.vaccine_id
                      LEFT JOIN staff s ON vr.staff_id = s.staff_id
                      LEFT JOIN room r ON vr.room_id = r.room_id
                      ORDER BY vr.record_id");
                dgvVaccinationReport.DataSource = vaccinationReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load report data.\n\n{ex.Message}", "Report Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSelectedView()
        {
            if (cboViews.SelectedItem is ViewOption option)
            {
                LoadView(option.ViewName);
            }
        }

        private void LoadView(string viewName)
        {
            try
            {
                currentViewReport = DBHelper.ExecuteQuery($"SELECT * FROM {viewName}");
                dgvViews.DataSource = currentViewReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load {viewName}.\n\n{ex.Message}", "View Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefreshView_Click(object sender, EventArgs e)
        {
            LoadSelectedView();
        }

        private void BtnExportPerson_Click(object sender, EventArgs e)
        {
            ExportPersonReport();
        }

        private void BtnExportVaccine_Click(object sender, EventArgs e)
        {
            ExportVaccineReport();
        }

        private void BtnExportVaccination_Click(object sender, EventArgs e)
        {
            ExportVaccinationReport();
        }

        private void ExportPersonReport()
        {
            if (personReport == null || personReport.Rows.Count == 0)
            {
                MessageBox.Show("There is no person report data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var summary = BuildSummaryTable("Person", "Count", personReport.Rows.Cast<DataRow>()
                .Select(row => new KeyValuePair<string, object>(GetFullName(row), 1)));

            ExportExcel(
                "PersonReport.xlsx",
                "Person List Report",
                personReport,
                summary,
                "Persons Registered");
        }

        private void ExportVaccineReport()
        {
            if (vaccineReport == null || vaccineReport.Rows.Count == 0)
            {
                MessageBox.Show("There is no vaccine report data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var summary = BuildSummaryTable("Expiry Month", "Count", vaccineReport.Rows.Cast<DataRow>()
                .Select(row => new KeyValuePair<string, object>(GetExpiryMonth(row), 1)));

            ExportExcel(
                "VaccineInventory.xlsx",
                "Vaccine Inventory Report",
                vaccineReport,
                summary,
                "Vaccine Expiry Distribution");
        }

        private void ExportVaccinationReport()
        {
            if (vaccinationReport == null || vaccinationReport.Rows.Count == 0)
            {
                MessageBox.Show("There is no vaccination report data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var summary = BuildSummaryTable("Vaccine", "Count", vaccinationReport.Rows.Cast<DataRow>()
                .Select(row => new KeyValuePair<string, object>(Convert.ToString(row["Vaccine"]) ?? string.Empty, 1)));

            ExportExcel(
                "VaccinationHistory.xlsx",
                "Vaccination History Report",
                vaccinationReport,
                summary,
                "Vaccinations Per Vaccine");
        }

        private static string GetFullName(DataRow row)
        {
            var firstName = Convert.ToString(row["First Name"]) ?? string.Empty;
            var lastName = Convert.ToString(row["Last Name"]) ?? string.Empty;
            return (firstName + " " + lastName).Trim();
        }

        private static string GetExpiryMonth(DataRow row)
        {
            if (row["Expiry Date"] == DBNull.Value)
            {
                return "Unknown";
            }

            return Convert.ToDateTime(row["Expiry Date"]).ToString("MMM yyyy");
        }

        private static DataTable BuildSummaryTable(string keyColumn, string valueColumn, IEnumerable<KeyValuePair<string, object>> source)
        {
            var summary = new DataTable();
            summary.Columns.Add(keyColumn, typeof(string));
            summary.Columns.Add(valueColumn, typeof(object));

            foreach (var group in source.GroupBy(item => item.Key))
            {
                if (group.Any())
                {
                    summary.Rows.Add(group.Key, group.Sum(item => Convert.ToInt32(item.Value)));
                }
            }

            return summary;
        }

        private void ExportExcel(string fileName, string reportTitle, DataTable data, DataTable chartData, string chartTitle)
        {
            using (var saveDialog = new SaveFileDialog
            {
                Title = "Save Excel Report",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = fileName,
                DefaultExt = "xlsx",
                AddExtension = true,
                OverwritePrompt = true
            })
            {
                if (saveDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var outputPath = saveDialog.FileName;
                var logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.ico");

                try
                {
                    ManagedXlsxWriter.ExportReport(outputPath, reportTitle, data, chartData, chartTitle, logoPath);
                    MessageBox.Show($"Export complete:\n{outputPath}", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed.\n\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private sealed class ViewOption
        {
            public ViewOption(string displayName, string viewName)
            {
                DisplayName = displayName;
                ViewName = viewName;
            }

            public string DisplayName { get; }
            public string ViewName { get; }

            public override string ToString()
            {
                return DisplayName;
            }
        }
    }
}
