# Client/Server Application in C#

## Description

This project implements a distributed Client/Server solution using C# and .NET 8.0, with data storage in a SQL Server database. It was developed as part of the **Advanced Programming course (Code: 00830)** during the **2nd Semester 2025**.

The application allows **clients** to connect to the server to **place and view orders**, while a **central administrator** can **register and consult** Item Types, Items, Clients, Delivery Personnel, and Orders.

---

## Project Structure

- **AppServidor**  
  Application used by the administrator. It connects to the database and listens for client connections over TCP.

- **AppCliente**  
  Application used by clients to authenticate and place orders. It only communicates with the server and **does not access the database directly**.

- **CapaComunicaciones**  
  Shared library containing data structures, network protocols, and data transfer objects (DTOs).

---

## Features

### Server Application (Administrator):
- Register and consult:
  - Item Types
  - Items
  - Clients
  - Delivery Personnel
  - Orders (header and detail)
- Automatic inventory control.
- Data validation (unique IDs, valid dates, active/inactive status).
- Real-time event logging (log).
- Live display of connected client count.
- Supports up to **5 simultaneous TCP connections**.

### Client Application:
- Client validation via identification number.
- Client's full name always visible in the interface.
- Place orders:
  - Selection of active items.
  - Validation of availability and stock.
  - Orders update item stock automatically.
- View orders:
  - All orders made by the current client.
  - Search by order ID.

---

## System Requirements

- Windows 10/11
- Visual Studio 2022 or later
- .NET 8.0 SDK
- SQL Server 2019+ (Express or higher)

---

## Technologies Used

- C# (.NET 8.0)
- Windows Forms
- SQL Server (ADO.NET)
- TCP Sockets
- Multithreading

---

##  Installation and Execution

1. Clone this repository:
   ```bash
   git clone https://github.com/your-username/Project_2.git
Open the solution in Visual Studio (Project_2.sln).

Check and update the SQL Server connection string in AppServidor.

Run the AppServidor project first.

Then run the AppCliente project and log in using a registered client ID.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Author
Keneth Mendez
Advanced Programming Course – 2nd Semester 2025 – UNED
