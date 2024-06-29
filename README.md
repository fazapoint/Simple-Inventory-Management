# Simple-Inventory-Management

## Overview

Simple-Inventory-Management is a web application designed to help manage product inventories. The application features two main views: 
1. **Managing Products**: Allows users to add, update, and delete products.
2. **Creating Transactions**: Supports restocking and selling products, with corresponding adjustments to the product stock levels.

When a transaction of type "restock" is created, the stock level of the product increases. Conversely, when a transaction of type "sold" is created, the stock level decreases.

## Features

- **Product Management**: Add, update, and delete products in the inventory.
- **Transaction Management**: Create transactions to restock or sell products.
- **Real-Time Stock Updates**: Automatically adjust stock levels based on transactions.

## Technologies Used

- **ASP.NET Core**: Backend framework.
- **Entity Framework Core**: ORM for database operations.
- **SQL Server**: Database system.
- **Docker**: Containerization for application deployment.
- **Bootstrap**: Frontend styling.

## Getting Started

### Prerequisites

- **Docker**: Ensure Docker is installed and running on your machine.
- **SQL Server**: Ensure SQL Server is available and accessible.

### Running the Project

1. **Clone the Repository**

    ```bash
    git clone https://github.com/yourusername/Simple-Inventory-Management.git
    cd Simple-Inventory-Management
    ```

2. **Configure the SQL Server**

    Ensure that SQL Server is running and accessible with the following credentials:

    - **Server**: `demodb`
    - **Port**: `1433`
    - **Username**: `faza`
    - **Password**: `faza`

3. **Update the Connection String**

    In your `appsettings.json` file, update the connection string to match your SQL Server configuration:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=demodb;Database=InventoryDb;User Id=faza;Password=faza;"
    }
    ```

4. **Build and Run the Docker Containers**

    Navigate to the root directory of your project and run the following command to build and start the application using Docker:

    ```bash
    docker-compose up --build
    ```

    This command will start the application on port `8080`.

5. **Access the Application**

    Open your browser and navigate to `http://localhost:8080` to access the Simple-Inventory-Management application.

### Project Structure

- **Controllers**
  - `ProductController`: Manages product-related actions.
  - `TransactionController`: Manages transaction-related actions.

- **Views**
  - `Products`: Contains views for adding, updating, and listing products.
  - `Transactions`: Contains views for creating and listing transactions.

- **Models**
  - `Product`: Represents a product in the inventory.
  - `Transaction`: Represents a transaction that modifies product stock levels.

## Usage

### Managing Products

1. Navigate to the **Products** section.
2. Add new products by filling in the required information.
3. Update or delete existing products as needed.

### Creating Transactions

1. Navigate to the **Transactions** section.
2. Select the type of transaction (Restock or Sold).
3. Choose the product and specify the quantity.
4. Save the transaction to update the stock level accordingly.

Thank you for using Simple-Inventory-Management! We hope it makes managing your inventory easier and more efficient.
