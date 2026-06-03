using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal static class UiTheme
    {
        public static readonly Color AppBackColor = Color.FromArgb(245, 247, 250);
        public static readonly Color SurfaceColor = Color.White;
        public static readonly Color BorderColor = Color.FromArgb(214, 219, 224);
        public static readonly Color TextColor = Color.FromArgb(33, 37, 41);
        public static readonly Color PrimaryColor = Color.FromArgb(0, 102, 204);
        public static readonly Color PrimaryHover = Color.FromArgb(0, 86, 179);
        public static readonly Color SecondaryColor = Color.White;

        public static void ApplyForm(Form form, bool dialog = false)
        {
            form.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            form.BackColor = AppBackColor;
            form.ForeColor = TextColor;

            if (dialog)
            {
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterParent;
            }
        }

        public static void ApplySurface(Control control)
        {
            control.BackColor = SurfaceColor;
            control.ForeColor = TextColor;
        }

        public static void ApplyDataGrid(DataGridView grid)
        {
            grid.BackgroundColor = SurfaceColor;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = BorderColor;
            grid.DefaultCellStyle.BackColor = SurfaceColor;
            grid.DefaultCellStyle.ForeColor = TextColor;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(225, 236, 248);
            grid.DefaultCellStyle.SelectionForeColor = TextColor;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 238, 245);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
        }

        public static void ApplyTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = SurfaceColor;
            textBox.ForeColor = TextColor;
            textBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        public static void ApplyComboBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.BackColor = SurfaceColor;
            comboBox.ForeColor = TextColor;
            comboBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        public static void ApplyDatePicker(DateTimePicker picker)
        {
            picker.CalendarForeColor = TextColor;
            picker.CalendarMonthBackground = SurfaceColor;
            picker.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        public static void ApplyLabel(Label label, bool heading = false)
        {
            label.ForeColor = TextColor;
            label.Font = new Font("Segoe UI", heading ? 10F : 9F, heading ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point);
        }

        public static void ApplyPrimaryButton(Button button)
        {
            StyleButton(button, PrimaryColor, Color.White, PrimaryHover);
        }

        public static void ApplySecondaryButton(Button button)
        {
            StyleButton(button, SecondaryColor, TextColor, Color.FromArgb(242, 242, 242));
        }

        private static void StyleButton(Button button, Color backColor, Color foreColor, Color hoverColor)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = BorderColor;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Cursor = Cursors.Hand;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button.UseVisualStyleBackColor = false;

            button.MouseEnter += (s, e) =>
            {
                if (button.Enabled)
                {
                    button.BackColor = hoverColor;
                }
            };

            button.MouseLeave += (s, e) =>
            {
                if (button.Enabled)
                {
                    button.BackColor = backColor;
                }
            };
        }
    }
}
