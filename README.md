New developer setup

The project has the following development dependencies which need to be installed beforehand:
.NET 8.0 SDK -> https://dotnet.microsoft.com/en-us/download/dotnet/8.0

The project makes use of a code-first approach which requires the developer to run the migrations in order to seed the tables, stored procedures and/or data.
To execute the migrations, navigate to the 'Todo' project folder and run the following command:
dotnet ef database upgrade
If the command returns an error of 'No project was found', ensure that you are in the project folder and not in the solution.
If the command returns an error that is cannot execute the entity framework instruction, run the following command to restore the dotnet entity framework tool:
dotnet tool restore

This will ensure that the relevant tools are available.

Rerun the following command which should run the migrations:
dotnet ef database upgrade

Once the migration is completed and is successful, you can start up the application from your IDE.
If it is the first time that the application is started you will need to trust the ASP.Net Core SSL Certificate before continuing.
A security warning will come up asking you to confirm that you want to install the locahost certificate. Click on yes to continue the application execution.

The application should now be up and running and you should see the login page at https://locahost:7005 or which ever other port is configured for the project.
