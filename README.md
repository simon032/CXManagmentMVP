Database ER Diagram 
![ERD V 4](https://github.com/user-attachments/assets/924960eb-e3c8-46fc-8547-9a6a223430ad)

Project Initial Setup Tutorial
Follow the steps below to configure the solution startup projects and set up the database migration process correctly.

1. Configuring Startup Projects
Right-click on the Solution and select Set Startup Projects.

In the left pane, select Startup Project.

Choose the option "Multiple startup projects".

Set CXManagement.API to Start.

Set CXManagement.Presentation to Start.

Click OK to apply the changes.

2. Database Migration Setup
Open the Package Manager Console.

Set the Default project to CXManagement.Infrastructure.

Execute the following commands to create and apply the first migration:
        Add-Migration InitialMigration
        Update-Database
