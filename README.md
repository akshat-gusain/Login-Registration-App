# ASP.NET Core Web API - Registration and Login API

This project demonstrates a simple **ASP.NET Core Web API** with a **SQL Server** backend. The project includes functionality for user registration and login. The project is built with two APIs:

- **Registration API** to register users.
- **Login API** to authenticate users.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Database Setup](#database-setup)
- [Project Setup](#project-setup)
- [APIs](#apis)
- [Usage with Postman](#usage-with-postman)
- [Troubleshooting](#troubleshooting)
- [License](#license)

---

## Prerequisites

Before you begin, ensure you have the following installed:

- **Visual Studio** (any recent version with ASP.NET Core support)
- **SQL Server** (Express or full edition)
- **Postman** (for API testing)

## Database Setup

1. **Open SQL Server** and create a new database named `TestToys`.
2. Run the following query to create a table for user registration:

    ```sql
    CREATE DATABASE TesttToys;

    USE TesttToys;

    CREATE TABLE Registration (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        UserName VARCHAR(100),
        Password VARCHAR(100),
        Email VARCHAR(100),
        IsActive INT
    );

    SELECT * FROM Registration;
    ```

This will set up the table needed for registration and login.

## Project Setup

1. **Clone the repository** to your local machine.
   
    ```bash
    git clone https://github.com/your-username/your-repo-name.git
    ```

2. Open the project in **Visual Studio**.

3. Go to `appsettings.json` and update the connection string with your **SQL Server** instance name:

    ```json
    "ConnectionStrings": {
        "ToysCon": "Data Source=LAPTOP-41FM8F54\\MSSQL2019;Initial Catalog=TesttToys;Integrated Security=true"
    }
    ```

4. **Run the project** by pressing `F5` or `Ctrl+F5`. The project will launch the browser with the Swagger UI by default.

## APIs

### 1. Registration API

- **Method:** `POST`
- **URL:** `/api/Registration/registration`
- **Description:** This API registers a new user into the system.
- **Request Body:**

    ```json
    {
        "UserName": "Admin",
        "Password": "123",
        "Email": "admin@example.com",
        "IsActive": 1
    }
    ```

### 2. Login API

- **Method:** `POST`
- **URL:** `/api/Registration/login`
- **Description:** This API allows users to log in.
- **Request Body:**

    ```json
    {
        "Email": "admin@example.com",
        "Password": "123"
    }
    ```

## Usage with Postman

1. **Start the project server** in Visual Studio. 
   
   If the project launches on `https://localhost:44315`, your Postman request URL should look like this:

   - **Registration API:** `https://localhost:44315/api/Registration/registration`
   - **Login API:** `https://localhost:44315/api/Registration/login`

2. **Make a `POST` request** to the registration API with the following body:

    ```json
    {
        "UserName": "Admin",
        "Password": "123",
        "Email": "test@gmail.com",
        "IsActive": "1"
    }
    ```

3. **Make a `POST` request** to the login API with the following body:

    ```json
    {
        "Email": "test@gmail.com",
        "Password": "123"
    }
    ```

4. Check the **SQL Server** by running the query:

    ```sql
    SELECT * FROM Registration;
    ```

## Troubleshooting

- If you encounter errors when making API requests, ensure that your **SQL Server** is running, and that the connection string in `appsettings.json` is correct.
  
- If you face issues with **Postman** requests, verify that the **URL** is correct based on the port used by the project in **Visual Studio**.

- **SQL Injection Prevention**: The login API uses parameterized queries to prevent SQL injection. Always validate and sanitize inputs before interacting with the database.

## License

This project is licensed under the MIT License.
