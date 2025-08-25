using System;
using System.Drawing;
using System.Windows.Forms; // enables access to GUI components

/*
Things To Understand:
---DISPLAY---
- display refers to the screen that shows the numbers after they are clicked
- Dock is used to anchor the screen to the top of the window
- ReadOnly = true prevents the user from typing in it
- TextAlign = HorizontalAlignment.Right makes the numbers appear from the right side

- Font("font_name", font_size) brings in the desired font
- 
*/

public class MainForm : Form
{
    private TextBox display;    // acts as the screen for the calculator
    private TableLayoutPanel buttonGrid;    // creates the grid for the buttons

    public MainForm()       // This is the constructor where you set up the form
    {
        Text = "Calculator";                        // Window Title
        Size = new Size(300, 400);                  // Window size (width, height)
        StartPosition = FormStartPosition.CenterScreen;

        /*  */
        display = new TextBox
        {
            Dock = DockStyle.Top,                   // anchors the display screen to the top of the window
            Font = new Font("Segoe UI", 20),
            ReadOnly = true,
            TextAlign = HorizontalAlignment.Right
        };
        Controls.Add(display);

        // The grid is created here with 5 rows, 4 columns
        buttonGrid = new TableLayoutPanel
        {
            RowCount = 5,
            ColumnCount = 4,
            Dock = DockStyle.Fill
        };

        for (int i = 0; i < buttonGrid.RowCount; i++)
        {
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / buttonGrid.RowCount));
        }
        
        for (int i = 0; i < buttonGrid.RowCount; i++)
        {
            buttonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / buttonGrid.ColumnCount));
        }
        Controls.Add(buttonGrid);

        // Displays in the window in this order
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

        // We'll add logic here in the next step
        display.Text += value;
    }
}