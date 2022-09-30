# Usage Instructions

### 2 Options for running the application:

1. Test directly on live Azure website: [Inventory Tracker Web Application](https://inventory-tracker.azurewebsites.net).
	* For best results, please use a full screen web browser.

2. Test locally in [Visual Studio](https://visualstudio.microsoft.com/).
	* Download or clone the inventory-tracker project from [GitHub](https://github.com/b-edward/inventory-tracker).
	* Run the database server:
		1. In the *DataServer* folder, open **DataServer.sln** in Visual Studio.
		2. From the main menu, select Debug -> Start Debugging.
	* Run the inventory tracker:
		1. In the *InventoryTracker* folder, open **InventoryTracker.sln** in Visual Studio.
		2. From the main menu, select Debug -> Start Debugging.

---

### How to use the application:

1. The application starts with a view of the total inventory table for all unsold items. The inventory table can be viewed any time by clicking `View Inventory`.

2. To edit the inventory, click `Edit Inventory`. Then click on a data table to edit.	
	
	> `Products` are types (e.g. Snowboard).
	> 
	> `Items` are individual units of a product type (e.g. Snowboard #231).
	> 
	> `Warehouses` are locations where an item unit can be assigned (e.g. Waterloo #12).

3. Clicking on a table button will display an input form, an `Add New` and `Update` button, as well as a view of all records for that selection. 

4. To `Add New` records, fill out the form with the new details.
	* The ID for that table is not required for new records, because the ID is auto-generated by the database.
	* When adding an **Item**, the ProductID and WarehouseID must already exist in the database.
	* Items may be assigned to a warehouse by entering that warehouse's ID. To Un-assign, enter 0.
		* When an item is assigned to a warehouse, a new record is automatically created in the WarehouseItem table in the database.
	
5. To `Update` records, fill out the new details for a particular ID.
	* The ID is required to identify what record to update.
	* When updating an **Item**, the ProductID and WarehouseID (if assigning) must already exist in the database.

6. A note on **Delete** functionality:
	* Items are not deleted from the database, their availability is instead set to "Sold" status. 
		* When an item is set to "Sold", it is no longer assigned to a warehouse, and is deleted from the WarehouseItem table in the database.
	* Products are not deleted from the database, their status is instead set to "Discontinued". 
	* Warehouses are not deleted from the database, their status is instead set to "Closed / Not Active".

---

# Implementation Details

This application has two components: 
1. A web client application to handle business logic and present the UI.
2. A web API service to access a MySQL database.

The application has been designed with extensibility and mainainability in mind. In keeping with SOLID principles, I have made use of interfaces and delegates, with classes and methods having a single responsibility wherever possible. I created a secondary web API service to allow access from any browser, and to easily accommodate mobile or desktop versions of the application in the future.

### 1. [Inventory Tracker Web Application](https://github.com/b-edward/inventory-tracker/tree/main/InventoryTracker)

The Inventory Tracker is the client web application for a logistics company. It was developed in ASP.NET and is hosted on Microsoft Azure App Service. It presents the user interface, allowing basic CRUD Functionality. The application will validate user input, create SQL queries, send the query requests to the DataServer via TCP/IP, parse the response and display it. 

### 2. [Data Server Web Service](https://github.com/b-edward/inventory-tracker/tree/main/DataServer)

The data access component is accomplished by the DataServer web API service. It was developed as a .NET console application, and is hosted on a Microsoft Azure Virtual Machine. This multi-threaded server allows multiple simultaneous clients to access the MySQL database via TCP/IP. 

The DataServer transfers data using a custom protocol, loosely based on REST/HTTP commands. 

Client requests must:
* Start with a verb command followed by a new line character (\n)
	* Commands supported are PUT, GET, POST, and DELETE
* End with a SQL query string corresponding to the command
	* For example: "GET\nSELECT * FROM 'Item';" will return all records in the Item table

Server responses:
* Start with an HTTP status code, followed by a new line character
* End with a server response message
	* Read table data is formatted with an ampersand '&' separating each record, and a comma ',' separating each field
	* For example: "200\n1,Surfboard,0&2,Snowboard,1" 
	
---

### Questions or Comments?

Please contact me at <eboado8862@conestogac.on.ca>. 	
