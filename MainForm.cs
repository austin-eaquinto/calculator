using System;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form        // 
{
    private TextBox display;
    private TableLayoutPanel buttonGrid;

    public MainForm()
    {
        Text = "Calculator";
        Size = new Size(300, 400);
        StartPosition = FormStartPosition.CenterScreen;

        // Main layout container with 2 rows: display and button grid
        var mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            Padding = new Padding(10)
        };

        // Row 0: fixed height for display
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        // Row 1: fills remaining space
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        Controls.Add(mainLayout);

        // Display textbox
        display = new TextBox
        {
            Font = new Font("Segoe UI", 20),
            ReadOnly = true,
            TextAlign = HorizontalAlignment.Right,
            Dock = DockStyle.Fill
        };
        mainLayout.Controls.Add(display, 0, 0);

        // Button grid
        buttonGrid = new TableLayoutPanel
        {
            RowCount = 4,
            ColumnCount = 4,
            Dock = DockStyle.Fill,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        for (int i = 0; i < buttonGrid.RowCount; i++)
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / buttonGrid.RowCount));

        for (int i = 0; i < buttonGrid.ColumnCount; i++)
            buttonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / buttonGrid.ColumnCount));

        mainLayout.Controls.Add(buttonGrid, 0, 1);

        // Button labels
        string[] buttons = {
            "7", "8", "9", "/",
            "4", "5", "6", "*",
            "1", "2", "3", "-",
            "0", "C", "=", "+"
        };

        foreach (string label in buttons)
        {
            var btn = new Button
            {
                Text = label,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16)
            };
            btn.Click += Button_Click;
            buttonGrid.Controls.Add(btn);
        }
    }

    private void Button_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;
        string value = btn.Text;

        switch (value)
        {
            case "C":
                display.Text = "";
                break;
            case "=":
                try
                {
                    display.Text = new System.Data.DataTable().Compute(display.Text, null).ToString();
                }
                catch
                {
                    display.Text = "Error";
                }
                break;
            default:
                display.Text += value;
                break;
        }
    }
}