// Imports namespaces for basic types, drawing, and Windows Forms GUI components
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class MainForm : Form        // MainForm inherits from Form, which makes a window
{
    [DllImport("user32.dll")]
    static extern bool HideCaret(IntPtr hWnd);
    
    // variables for the button grid and section that displays clicked numbers/signs
    // intializes each as the part of the Form type it needs to be
    private TextBox display;
    private TableLayoutPanel buttonGrid;

    public MainForm()               // form constructor, sets up the UI
    {
        Text = "Calculator";        // window title
        Size = new Size(300, 400);  // window size
        StartPosition = FormStartPosition.CenterScreen; // window start position

        // mainLayout container with 2 rows: display and button grid
        // in other words, this is where everything is added to
        var mainLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,      // says to fill the window with the columns and rows
            RowCount = 2,               // row0- display above row1- button grid
            ColumnCount = 1,            // only one column, holds display and buttonGrid
            Padding = new Padding(10),   // ten pixels of space bewteen rows (and columns)
            // BackColor = Color.White
        };

        // Row 0: fixed height of (60) for display
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        // Row 1: fills remaining space
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        Controls.Add(mainLayout);       // adds the mainLayout to the Form/window

        // For the 'display' textbox
        display = new TextBox
        {
            Font = new Font("Segoe UI", 20),        // font type and size
            ReadOnly = true,                        // only reading allowed, no typing
            TextAlign = HorizontalAlignment.Right,  // makes the numbers and signs appear from the right side of the texbox
            Dock = DockStyle.Fill,
            TabStop = false,                         // removes focus rectangle (blue line) from underlining display Textbox on startup
            // BackColor = Color.White
        };
        mainLayout.Controls.Add(display, 0, 0);     // adds it to the first row
        display.GotFocus += display_GotFocus;

        // For the button grid
        buttonGrid = new TableLayoutPanel
        {
            RowCount = 4,               // 4x4 grid
            ColumnCount = 4,
            Dock = DockStyle.Fill,      // fills each individual cell
            Margin = new Padding(0),    // these two lines mean no extra padding or margin in each cell
            Padding = new Padding(0),
        };

        // These for loops set each row and column of the buttonGrid to take equal space in the grid
        for (int i = 0; i < buttonGrid.RowCount; i++)
            buttonGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / buttonGrid.RowCount));

        for (int i = 0; i < buttonGrid.ColumnCount; i++)
            buttonGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / buttonGrid.ColumnCount));

        mainLayout.Controls.Add(buttonGrid, 0, 1);      // adds buttonGrid to the second row of mainLayout

        // Defines lables for each of the calculator buttons
        string[] buttons = {
            "7", "8", "9", "/",
            "4", "5", "6", "*",
            "1", "2", "3", "-",
            "0", "C", "=", "+"
        };

        foreach (string label in buttons)           // For each label:
        {
            var btn = new Button                    //create the button,
            {
                Text = label,                       // set the text,
                Dock = DockStyle.Fill,              // fill the cell,
                Font = new Font("Segoe UI", 16),    // set the font,
                TabStop = false,                     // removes focus rectangle from initialzing on grid
                // BackColor = Color.LightGray,
                // FlatStyle = FlatStyle.Flat,
                // FlatAppearance = { BorderColor = Color.DarkBlue}
            };
            btn.Click += Button_Click;              // have a click event handler,
            buttonGrid.Controls.Add(btn);           // add it to the grid
        }
    }

    private void display_GotFocus(object? sender, EventArgs e)
    {
        HideCaret(display.Handle);
    }

    // Event Handler for button clicks
    private void Button_Click(object? sender, EventArgs e)
    {
        // var btn = sender as Button;     // gets the button that was clicked

        if (sender is Button btn)
        {

            string value = btn.Text;        // gets the same button's label

            switch (value)
            {
                case "C":                   // if 'C' is clicked, clear the display
                    display.Text = "";
                    break;
                case "=":                   // if '=' is clicked,
                    try                     // do the math and display the answer, or
                    {
                        display.Text = new System.Data.DataTable().Compute(display.Text, null).ToString();
                        /* 
                        display.Text=...
                            - Assigns the calculated value as a string back to the calculator's display
                            - Replaces the expression with the answer

                        new System.Data.DataTable():
                            - from System.Data namespace
                            - usually used for storing tabular data
                            - used here to evaluate the expression

                        .Compute(display.Text, null):
                            - calls Compute method of DataTable instance
                            - display.Text is the expression as a string (1+2/3)
                            - null filters rows but is not needed here

                        .ToString():
                            - Converts the result of Compute to a string
                        */
                    }
                    catch           // if the function can't be done display "Error"
                    {
                        display.Text = "Error";
                    }
                    break;
                default:            // For all other buttons (+,-,*,/), append its label to the display
                    display.Text += value;
                    break;
            }
        }
        this.ActiveControl = null;  // turns off the focus rectangle (blue line) that appears around each button that is clicked
    }
}