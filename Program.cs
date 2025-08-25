// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using System;
using System.Windows.Forms; // enables access to GUI components

class Program
{
    [STAThread]     // required for Windows Forms to work properly
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());    // launches the GUI window
    }
    /*
    static void Main(string[] args)
    {

        Console.WriteLine("Console Calculator\n");

        int num1 = Convert.ToInt32(Console.ReadLine());
        string op = Console.ReadLine();          // +, -, *, /
        int num2 = Convert.ToInt32(Console.ReadLine());
        int result = 0;
        bool valid = true;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    Console.WriteLine("Cannot divide by zero.");
                    valid = false;
                }
                break;
            default:
                Console.WriteLine("Invalid operator.");
                valid = false;
                break;
        }
        if (valid)
            Console.WriteLine(result);
    }   */
}