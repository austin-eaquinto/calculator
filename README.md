# Simple C# Calculator

This project is a basic desktop calculator application built with **C#** and the **Windows Forms** framework. It provides a simple graphical interface for performing common arithmetic operations.

## Features

* **Four Basic Operations:** Supports addition (+), subtraction (-), multiplication (\*), and division (/).

* **Familiar Layout:** A clean 4x4 button grid for easy number and operator input.

* **Expression Display:** A text box that shows the full expression as you type.

* **Clear Functionality:** A 'C' button to quickly reset the display.

---

## Prerequisites

To build and run this application using VS Code, you will need to install the following:

* **`.NET SDK`**: This provides the command-line tools for building .NET applications.

* **`C# Dev Kit` extension**: An official extension from Microsoft that provides C# development capabilities in VS Code.

---

## How to Run

1. **Open a Terminal**: In VS Code, open the integrated terminal (`Ctrl` + `~`).

2. **Create a New Project**: Run the following command to create a new Windows Forms project:

   ```bash
   dotnet new winforms -n CalculatorApp
   ```

3. **Navigate to Project Folder**: Move into the newly created directory:

   ```bash
   cd CalculatorApp
   ```

4. **Add the Code**: Locate the `Form1.cs` file in the Explorer panel and replace its contents with your code.

5. **Run**: Execute the following command in the terminal to run the application:

   ```bash
   dotnet run
   ```

   This will build the project and launch the calculator application.

---

## Code Highlights

This project demonstrates several key skills crucial for a C# development role.

* **Clean Architecture and UI/UX Principles**: The application's UI is cleanly separated from its logic using the **Windows Forms** framework. The use of a **`TableLayoutPanel`** shows an understanding of how to build responsive and organized user interfaces.

* **Platform Interoperability**: The use of `[DllImport("user32.dll")]` to import and call a function from a native Windows library shows an ability to work with **platform-specific APIs** and an understanding of **interoperability**.

* **Event-Driven Programming**: The `Button_Click` event handler is a classic example of **event-driven programming**, a fundamental concept in application development where the program's flow is determined by user actions.

* **Expression Evaluation**: The logic for evaluating the mathematical expression, `new System.Data.DataTable().Compute(...)`, is a clever and efficient approach to parsing and calculating a string-based equation. It demonstrates **problem-solving skills** and an ability to leverage powerful, built-in framework capabilities.

* **Defensive Programming**: The `try-catch` block for handling potential calculation errors shows an understanding of **exception handling** and **defensive programming**, ensuring the application doesn't crash from invalid user input.

---

## Next Steps & Potential Improvements

As the user consider the following to further demonstrate skills or to add features:

* **Extend Functionality**: Add more complex operations like square roots, exponents, or percentage calculations.

* **Refactor for Maintainability**: Separate the UI and calculation logic into different files to improve code organization.

* **Unit Testing**: Write unit tests for the calculation logic to ensure it is robust and error-free.

* **User Experience**: Implement keyboard input support or history functionality.
