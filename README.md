# Project Name README

## Overview

This project is an MVC application built using C# for the code-behind and targeting the latest stable version of .NET Core(8.0). The application allows users to enter a variable amount of numbers, sort them in either ascending or descending order, and view the sorted results. Additionally, users can export all sorts as JSON.

## Assumptions

1. **Input Validation**: It is assumed that the input provided by the user consists only of integer values separated by commas or spaces. No other characters are considered valid input.

2. **Database Configuration**: The application assumes that a Microsoft SQL Server database is used for storing sorted data. The connection string is specified in the `appsettings.json` file.

3. **Feedback Mechanism**: Feedback to the user is provided through messages displayed in the MVC view. Success, validation issues, and errors are communicated accordingly.

4. **Exporting Sorts as JSON**: When exporting sorts as JSON, the application assumes that the user intends to download all sorts performed since the application was launched. The exported JSON file contains an array of objects, each representing a sort operation.

## Decisions

1. **Technology Stack**: The decision to use ASP.NET Core MVC with C# was made based on the familiarity of the development team with the technology stack and its suitability for building web applications.

2. **Database Provider**: Microsoft SQL Server was chosen as the database provider because it was stated in the test instructions.

3. **Frontend Framework**: The application uses Bootstrap for styling to ensure a responsive and visually appealing user interface.

4. **Sorting Algorithm**: The sorting algorithm used in this project is HeapSort. HeapSort was chosen after benchmarking it against other common sorting algorithms, including QuickSort, MergeSort, and the built-in LINQ OrderBy method. HeapSort demonstrated superior performance, especially for large datasets, making it the optimal choice for sorting the entered numbers efficiently. HeapSort is a comparison-based sorting algorithm that utilizes a binary heap data structure to arrange elements into a sorted order. It offers a time complexity of O(n log n), making it suitable for sorting large datasets with reasonable performance guarantees.

## Running the Application

To run the application locally:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or your preferred IDE.
3. Configure the database connection string in the `appsettings.json` file.
4. Build and run the application.
