# PageignitionAPI

Fork the solution from the GitHub Repo https://github.com/madhusudhan2502/PageignitionAPI
Open the solution in Visual Studio 2022 
Before running the api need to send the DB.
 Open the appsettings.json file
 
Change the DB Connection String to point to the local DB in your local machine and Create a new DB "paginationDb"

Then open the Package Manager Console and execute the below scripts one by one. Which will create table in the DB

1.add-migration
2.update-database

Then Run the attached SQL Script "PaginationAPI_Insert_Date.sql" that added with solution. which will insert the Data into the BondAppData Table.

Once done , Run the application and access this URL : https://localhost:44312/api/BondApp/


