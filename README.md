Cat Web Application - C# Entity Framework

Welcome to the Cat Web Application repository! This web application is built in C# using Entity Framework and provides a delightful experience for cat enthusiasts. The application features three main sites: Home (which displays a random cat), 
Breeds (showcasing cat breeds), and Cats (providing a list of all available cats). The data is stored in an MSSQL database. Please note that images are not provided in this repository.

Prerequisites

Before you can run the Cat Web Application, ensure that you have the following prerequisites installed:

    Visual Studio - You'll need a development environment to work with C#.
    SQL Server - Required for the MSSQL database.
    Entity Framework - Entity Framework is used for database operations.

Installation
 Clone this repository to your local machine:

    git clone https://github.com/your-username/cat-web-app.git
    
 Open the project in Visual Studio.
 Restore NuGet packages if necessary.

Database Setup

The database schema and initial data are managed in a separate repository:

    https://github.com/PiTrzos/webScraper

Make sure to follow the instructions in the webScraper repository to set up the database and populate it with data.

Running the Application

To run the Cat Web Application, follow these steps:

    Ensure that you have a SQL Server instance running and the database is set up according to the instructions in the webScraper repository.

    In Visual Studio, build the project and run the application.

    The application will start, and you can access it in your web browser at http://localhost:5018.

Accessing the Sites

The Cat Web Application provides the following main sites:
Home: Displays a random cat.

    http://localhost:5018/

Breeds: Showcases all cat breeds. You can access specific breed details by name, e.g. "exotic-breeds":

    http://localhost:port/breeds/exotic-breeds

Cats: Lists all available cats. You can access specific cat details by name, e.g. "bengal-cat":

    http://localhost:port/cats/bengal-cat

Please note that images for the cats are not provided in this repository.
