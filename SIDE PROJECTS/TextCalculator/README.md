# Text Calculator VERSION: 1.0.0 🔖

## General info ℹ️
* This project serves as a part of an interview for an internship at **Haselt**

## Technologies 💻
* React.JS
* ASP.NET CORE
* xUnit

## How to use 📘
1. Open the **TextCalculatorAppBE** folder and open the solution by running the *TextCalculatorApp.sln* project
2. After the browser window opens, copy the URL (ex.https://localhost:44393/api/text-calculator)
3. Navigate 1 folder back and open a terminal in the **text-calculator-appFE** folder and run **npm install** and close the terminal
4. Open **text-calculator-app** in a code editor and open the **App.JS** file inside the **src** folder
5. Now replace the URL in the apiUrl constant with the base URL that you copied in the second step (be sure to check if you have only 1 set of quotation marks and that the url is exactly as you copied it):
    from ex. - const apiUrl = `https://localhost:44393/api/text-calculator` <br/>to       - const apiUrl = PASTE HERE <-------
6. Finally open a terminal again in the **text-calculator-appFE** folder and run **npm start**

## Features ✨
List of ready features:
* The main purpose of the app is to sum numbers
* The numbers are to be divided by "," and decimals are marked with "."
* An empty user input (empty string) results with a "0" output string
* It can handle an infinite number of numbers
* If there is a missing number or numbers at any position it returns an exception message regarding the position of the missing numbers
* Negative numbers also return an exception with a list of all of them
* If the input contains elements that are not numbers an exception occurs and informs the user
