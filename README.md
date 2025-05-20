Database ER Diagram 
![ERD V 4](https://github.com/user-attachments/assets/924960eb-e3c8-46fc-8547-9a6a223430ad)

Project Initial Setup Tutorial:

  Right-click on the Solution and select Set Startup Projects.
  
  Select the option "Multiple startup projects".
  
  Set CXManagement.API to Start.
  
  Set CXManagement.Presentation to Start.
  
  Open the Package Manager Console.
  
  Set the Default project to CXManagement.Infrastructure.
  
  Run the following commands to create and apply the first migration.
    Add-Migration
    Update-Database
