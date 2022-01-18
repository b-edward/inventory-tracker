## Inventory Tracker Web Application

The Inventory Tracker is a web application for a logistics company. It was developed in ASP.NET and is hosted on Microsoft Azure App Service. It presents the user interface, allowing basic CRUD Functionality. The application will validate user input, create SQL queries, send the query requests to the DataServer via TCP/IP, parse the response and display it. 
For best results, please use a full screen web browser (mobile styling not supported at this time).

The user is able to:
* Create new products, items, and warehouses
* View a list of all inventory
	* View a list products, items, or warehouses
* Edit products, items, or warehouses
	* Assign or un-assign an item to a warehouse
	* Set an item to sold (to remove from active inventory)
* Delete products, items, or warehouses
	* Items, products and warehouses are not actually deleted, but set to inactive (or sold)

Notes: 
* Products represent a type of item, for example "Snowboard"
* Items represent individual units of a product, for example "Item #2006", which happens to be a Snowboard
* An item can be unnassigned, or assigned to only one warehouse at a time
* Only items available for sale are shown in the inventory view

## Data Server Web Service

The data access component is accomplished by the DataServer web API service. It was developed as a .NET console application, hosted on a Microsoft Azure Virtual Machine. This multi-threaded server allows multiple simultaneous clients to access the MySQL database via TCP/IP. 

The DataServer transfers data using a custom protocol, loosely based on REST/HTTP. 

Requests must:
* Start with a verb command followed by a new line character (\n)
* Commands supported are PUT, GET, POST, and DELETE
* Finally, a SQL query string corresponding to the command
	* For example: "GET\nSELECT * FROM 'Item';" will return all records in the Item table

Responses:
* Start with an HTTP status code, followed by a new line character
* If returning a read request, the data content follows
	* Read data is formatted with an ampersand '&' separating each record, and a comma ',' separating each field
	* For example: "200\n1,Surfboard,1" 
	
	