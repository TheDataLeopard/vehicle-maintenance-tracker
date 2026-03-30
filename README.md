# Vehicle-Maintenance-Tracker
The Vehicle Maintenance Tracker is a system designed to manage vehicle records and track maintenance history. It allows users to record service activities, monitor repairs, and maintain structured data related to vehicles and their servicing.

This project focuses on building a practical, real-world solution for managing vehicle maintenance data efficiently.

---

## Project Status
This project is currently a **Work in Progress (WIP)**.

The current version represents the foundational structure of the system, including core functionality and database design. Additional features, improvements, and refinements are planned for future development.

---

## Project Timeline
- Ongoing Development: March 2026 

---

## Technologies Used
- ASP.NET Core MVC  
- Entity Framework Core (Code-First)  
- SQL Server  
- C#  
- Razor Views
- QuestPDF  

---

## Features (Current)
- Add and manage vehicle records  
- Track service and maintenance history  
- Perform CRUD operations on service records  
- View detailed service history per vehicle 

---

## Database Design
The system is structured around a relational database that includes key entities such as:

- **Vehicles**  
- **Service History** 
- **Customers** 

### Relationships
- One Vehicle → Many Service Records  

The database is fully normalized with proper primary and foreign key constraints.

---

## Database Note
The SQL sample data are **not included** in this repository.
The database structure is currently under active development and is subject to change as the project evolves.

---

## Database Setup (Migrations)
This project uses **Entity Framework Core Code-First Migrations** to generate the database schema.

## Setup DB Connection String
1. Open the project in Visual Studio
2. Navigate and open the `appsettings.json` file
3. Change the `Server=ServerName` name to your SQL Server


<img width="1148" height="263" alt="image" src="https://github.com/user-attachments/assets/e9254558-6441-455a-a0c7-13b7352b7ebe" />


### Steps to create the database:

1. Open the project in Visual Studio  
2. Open **Package Manager Console**  
3. Run the following command:

```bash
Update-Database
```

<img width="918" height="258" alt="image" src="https://github.com/user-attachments/assets/e5a211cc-4c65-410c-b2db-d927ce95465c" />

This will:
- Create the database
- Apply all migrations
- Generate all tables and relationships automatically

---

## Future Updates
- Custom CSS (Currently uses bootstrap CSS)
- Improve UI/UX
- More Vehicle Information
- Ability to add reciepts to Service Records
- Add Search & Filtering
- Enable the System to run on a server
